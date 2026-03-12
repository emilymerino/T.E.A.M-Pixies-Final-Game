using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LCMinigameTitlePopUp : MonoBehaviour
{
    public float timeRemaining = 2f;
    public TextMeshProUGUI MinigameTitle;
    public LCInstructionsPopUp instructionsPopUp;

    void Start()
    {
        if (MinigameTitle == null)
        {
            MinigameTitle = GetComponent<TextMeshProUGUI>();
        }
        MinigameTitle.gameObject.SetActive(true); // show text
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime; // decrease time
        }
        else // timer stoped
        {
            MinigameTitle.gameObject.SetActive(false); // hide text
            instructionsPopUp.ShowInstructions(); // go to InstructionsPopUp script
            enabled = false; // stop script
        }
    }
}