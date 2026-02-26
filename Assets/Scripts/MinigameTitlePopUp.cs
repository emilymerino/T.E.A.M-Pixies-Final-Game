using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MinigameTitlePopUp : MonoBehaviour
{
    public float timeRemaining = 10f;
    public TextMeshProUGUI MinigameName;
    public InstructionsPopUp instructionsPopUp;

    void Start()
    {
        if (MinigameName == null)
        {
            MinigameName = GetComponent<TextMeshProUGUI>();
        }
        MinigameName.gameObject.SetActive(true); // show text
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime; // decrease time
        }
        else // timer stoped
        {
            MinigameName.gameObject.SetActive(false); // hide text
            instructionsPopUp.ShowInstructions(); // go to InstructionsPopUp script
            enabled = false; // stop script
        }
    }
}