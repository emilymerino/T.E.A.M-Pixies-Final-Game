using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InstructionsPopUpEM : MonoBehaviour
{
    public BMReadyButtonSelection bmReadyButtonSelection;
    public ReadyPopUpEM readyPopUpEM;

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
        Instructions.gameObject.SetActive(true); // show text
        bmReadyButtonSelection.ShowReadyButton();
    }

    public void HideInstructions()
    {
        Instructions.gameObject.SetActive(false); // hide text
        enabled = false;
        readyPopUpEM.ShowText();
    }
}
