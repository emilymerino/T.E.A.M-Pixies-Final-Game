using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LCInstructionsPopUp : MonoBehaviour
{
    public float timeRemaining = 1f;
    public TextMeshProUGUI Instructions;
    public LCBoardBehaviour boardBehaviour;
    public LCSetPattern setPattern;

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
            boardBehaviour.ShowBorder(); // go to BorderBehaviour script
            setPattern.ShowPattern(); // go to PatternBehaviour script
            enabled = false;
        }
    }
}