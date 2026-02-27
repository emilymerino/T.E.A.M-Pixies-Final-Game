using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClueManager : MonoBehaviour
{
    public static ClueManager Instance;


    public GameObject cluePopupPanel;
    public TMP_Text cluePopupText;

    public GameObject clueInventoryPanel;
    public Transform clueSlotsParent; 
    public GameObject clueSlotPrefab; 
    public Image clueDetailIcon;
    public TMP_Text clueDetailDescription;

    public List<ClueData> allClues = new List<ClueData>();
    private List<ClueData> foundClues = new List<ClueData>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UnlockClue(ClueData clue)
    {
        if (!foundClues.Contains(clue))
        {
            foundClues.Add(clue);
            ShowPopup(clue);
            AddClueToInventory(clue);
        }
    }

    private void ShowPopup(ClueData clue)
    {
        cluePopupText.text = "Clue Found: " + clue.clueName;
        cluePopupPanel.SetActive(true);

        Invoke("HidePopup", 2f);
    }

    private void HidePopup()
    {
        cluePopupPanel.SetActive(false);
    }

    private void AddClueToInventory(ClueData clue)
    {
        GameObject newSlot = Instantiate(clueSlotPrefab, clueSlotsParent);
        TMP_Text slotText = newSlot.GetComponentInChildren<TMP_Text>();
        slotText.text = clue.clueName;

        Button btn = newSlot.GetComponent<Button>();
        btn.onClick.AddListener(() => ShowClueDetails(clue));
    }

    private void ShowClueDetails(ClueData clue)
    {
        clueDetailIcon.sprite = clue.icon;
        clueDetailDescription.text = clue.description;
    }

    public void ToggleInventory()
    {
        clueInventoryPanel.SetActive(!clueInventoryPanel.activeSelf);
    }
}