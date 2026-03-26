using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LCInstructionsPopUp : MonoBehaviour
{
    public LCReadyButtonSelection readyButtonSelection;
    public LCLockBehaviour lockBehaviour;

    public TextMeshProUGUI Instructions;

    void Start()
    {
        if (Instructions == null)
        {
            Instructions = GetComponent<TextMeshProUGUI>();
        }
        Instructions.gameObject.SetActive(false); // starts hidden
    }

    public void ShowInstructions()
    {
        Instructions.gameObject.SetActive(true);
        readyButtonSelection.ShowReadyButton();
    }

    public void HideInstructions()
    {
        Instructions.gameObject.SetActive(false); 
        lockBehaviour.ShowLock();

        enabled = false;
    }
}