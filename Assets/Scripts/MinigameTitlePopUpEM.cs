using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MinigameTitlePopUpEM : MonoBehaviour
{
    public float timeRemaining = 3f;
    public TextMeshProUGUI MinigameTitle;
    public InstructionsPopUpEM instructionsPopUpEM;

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
            instructionsPopUpEM.ShowInstructions(); // go to InstructionsPopUpEM script
            enabled = false; // stop script
        }
    }
}
