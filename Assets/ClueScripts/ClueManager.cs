using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClueManager : MonoBehaviour
{
    public static ClueManager Instance;


    public GameObject cluePopupPanel;
    public TMP_Text cluePopupText;
    public Image cluePopupIcon;


    public GameObject clueInventoryPanel;
    public Transform clueSlotsParent;

    public Button openClueInventoryButton;
    public TMP_Text openClueInventoryButtonText;

    public Image clueDetailIcon;
    public TMP_Text clueDetailDescription;
    public Image clueDetailBackground;

    private List<ClueData> foundClues = new List<ClueData>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (clueInventoryPanel != null)
            clueInventoryPanel.SetActive(false);

        if (cluePopupPanel != null)
            cluePopupPanel.SetActive(false);

        if (clueDetailIcon != null)
            clueDetailIcon.enabled = false;

        if (clueDetailBackground != null)
            clueDetailBackground.enabled = false;

        if (clueDetailDescription != null)
            clueDetailDescription.text = "Select a clue to view details.";

 
        if (openClueInventoryButton != null)
        {
            openClueInventoryButton.onClick.RemoveAllListeners();
            openClueInventoryButton.onClick.AddListener(ToggleInventory);
        }

        UpdateButtonText();
    }

    public void UnlockClue(ClueData clue)
    {
        if (clue == null) return;
        if (foundClues.Contains(clue)) return;

        foundClues.Add(clue);

        ShowPopup(clue);
        CreateClueSlot(clue);
    }

    void ShowPopup(ClueData clue)
    {
        if (cluePopupPanel != null)
            cluePopupPanel.SetActive(true);

        if (cluePopupText != null)
            cluePopupText.text = clue.clueName;

        if (cluePopupIcon != null)
        {
            cluePopupIcon.sprite = clue.icon;
            cluePopupIcon.enabled = true;
        }

        CancelInvoke();
        Invoke(nameof(HidePopup), 2f);
    }

    void HidePopup()
    {
        if (cluePopupPanel != null)
            cluePopupPanel.SetActive(false);
    }

    void CreateClueSlot(ClueData clue)
    {
        GameObject slot = new GameObject(clue.clueName + "_Slot");
        slot.transform.SetParent(clueSlotsParent, false);

        RectTransform rect = slot.AddComponent<RectTransform>();
        rect.sizeDelta = new Vector2(100, 100);

        Image bg = slot.AddComponent<Image>();
        bg.color = new Color(0.4f, 0.4f, 0.45f, 1f);

        Button btn = slot.AddComponent<Button>();

        GameObject iconObj = new GameObject("Icon");
        iconObj.transform.SetParent(slot.transform, false);

        RectTransform iconRect = iconObj.AddComponent<RectTransform>();
        iconRect.anchorMin = Vector2.zero;
        iconRect.anchorMax = Vector2.one;
        iconRect.offsetMin = new Vector2(8, 8);
        iconRect.offsetMax = new Vector2(-8, -8);

        Image icon = iconObj.AddComponent<Image>();
        icon.sprite = clue.icon;
        icon.preserveAspect = true;
        icon.enabled = true;

        btn.onClick.AddListener(() =>
        {
            if (clueDetailIcon != null)
            {
                clueDetailIcon.sprite = clue.icon;
                clueDetailIcon.enabled = true;
            }

            if (clueDetailDescription != null)
                clueDetailDescription.text = clue.description;

            if (clueDetailBackground != null)
                clueDetailBackground.enabled = true;
        });
    }

    public void ToggleInventory()
    {
        if (clueInventoryPanel == null || openClueInventoryButtonText == null) return;

        bool isOpen = !clueInventoryPanel.activeSelf;
        clueInventoryPanel.SetActive(isOpen);

        Debug.Log("ToggleInventory clicked. Inventory is now: " + (isOpen ? "Open" : "Closed"));

        UpdateButtonText();
    }

    void UpdateButtonText()
    {
        if (openClueInventoryButtonText == null) return;

        if (clueInventoryPanel.activeSelf)
            openClueInventoryButtonText.text = "X";
        else
            openClueInventoryButtonText.text = "Clues";
    }
}