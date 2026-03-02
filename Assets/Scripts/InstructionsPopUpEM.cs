using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InstructionsPopUpEM : MonoBehaviour
{
    public ReadyPopUpEM readyPopUpEM;

    public float timeRemaining = 20f;
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
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime; // decrease time
        }
        else // timer stoped
        {
            Instructions.gameObject.SetActive(false); // hide text
            enabled = false;
            readyPopUpEM.ShowText();
        }
    }
}
