using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClueManager : MonoBehaviour
{
    public static ClueManager Instance;


    public GameObject openInventoryButton;
    public GameObject exitInventoryButton;
    public GameObject cluePopupPanel;
    public TMP_Text cluePopupText;
    public Image cluePopupIcon;

    public GameObject clueInventoryPanel;
    public Transform clueSlotsParent; // grid layout panel


    public Image clueDetailIcon;
    public TMP_Text clueDetailDescription;

    private List<ClueData> foundClues = new List<ClueData>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        cluePopupPanel.SetActive(false);
        clueInventoryPanel.SetActive(false);

        clueDetailIcon.enabled = false;
        clueDetailDescription.text = "Select a clue to view details.";
    }

    public void UnlockClue(ClueData clue)
    {
        if (foundClues.Contains(clue))
            return;

        foundClues.Add(clue);

        ShowPopup(clue);
        CreateClueSlot(clue);
    }

    private void ShowPopup(ClueData clue)
    {
        cluePopupPanel.SetActive(true);

        cluePopupText.text = "Clue Found: " + clue.clueName;

        if (cluePopupIcon != null)
        {
            cluePopupIcon.sprite = clue.icon;
            cluePopupIcon.enabled = true;
            cluePopupIcon.preserveAspect = true;
        }

        CancelInvoke();
        Invoke(nameof(HidePopup), 2f);
    }

    private void HidePopup()
    {
        cluePopupPanel.SetActive(false);
    }

    // creates slot automatically
    private void CreateClueSlot(ClueData clue)
    {
        // create button object
        GameObject slot = new GameObject(clue.clueName);

        slot.transform.SetParent(clueSlotsParent, false);

        RectTransform rect = slot.AddComponent<RectTransform>();
        rect.sizeDelta = new Vector2(100, 100);

        Image background = slot.AddComponent<Image>();
        background.color = new Color(0.8f, 0.8f, 0.8f, 1f);

        Button button = slot.AddComponent<Button>();

        // create icon child
        GameObject iconObj = new GameObject("Icon");
        iconObj.transform.SetParent(slot.transform, false);

        RectTransform iconRect = iconObj.AddComponent<RectTransform>();
        iconRect.anchorMin = Vector2.zero;
        iconRect.anchorMax = Vector2.one;
        iconRect.offsetMin = new Vector2(10, 10);
        iconRect.offsetMax = new Vector2(-10, -10);

        Image iconImage = iconObj.AddComponent<Image>();
        iconImage.sprite = clue.icon;
        iconImage.preserveAspect = true;

        // click event
        button.onClick.AddListener(() =>
        {
            clueDetailIcon.enabled = true;
            clueDetailIcon.sprite = clue.icon;
            clueDetailDescription.text = clue.description;
        });
    }

    public void ToggleInventory()
    {
        bool isActive = !clueInventoryPanel.activeSelf;

        clueInventoryPanel.SetActive(isActive);

        // hide open button when inventory is open
        if (openInventoryButton != null)
            openInventoryButton.SetActive(!isActive);

        // show exit button when inventory is open
        if (exitInventoryButton != null)
            exitInventoryButton.SetActive(isActive);
    }
}