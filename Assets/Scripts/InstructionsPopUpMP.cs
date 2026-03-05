using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InstructionsPopUpMP : MonoBehaviour
{
    public float timeRemaining = 10f;
    public TextMeshProUGUI Instructions;
    public BoardBehaviourMP boardBehaviourMP;
    public SetPatternMP setPatternMP;

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
            boardBehaviourMP.ShowBorder(); // go to BorderBehaviour script
            setPatternMP.ShowPattern(); // go to PatternBehaviour script
            enabled = false;
        }
    }
}