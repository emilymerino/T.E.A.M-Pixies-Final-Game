using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MinigameTitlePopUpEM : MonoBehaviour
{
    //public BMReadyButtonSelection bmReadyButtonSelection;
    public InstructionsPopUpEM instructionsPopUpEM;

    public float timeRemaining = 2f;
    public TextMeshProUGUI MinigameTitle;

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
            instructionsPopUpEM.ShowInstructions();
            //bmReadyButtonSelection.gameObject.SetActive(true);
            enabled = false; // stop script
        }
    }
}
