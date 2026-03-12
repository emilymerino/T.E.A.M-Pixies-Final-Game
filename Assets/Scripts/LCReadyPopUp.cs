using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LCReadyPopUp : MonoBehaviour
{
    public LCPlayersSelection playersSelection;
    public float timeRemaining = 3f;
    public TextMeshProUGUI PlayersTurnText;

    void Start()
    {
        if (PlayersTurnText == null)
        {
            PlayersTurnText = GetComponent<TextMeshProUGUI>();
        }
        PlayersTurnText.gameObject.SetActive(false); // starts hidden
    }

    public void ShowText()
    {
        PlayersTurnText.gameObject.SetActive(true); // show text
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime; // decrease time
        }
        else // timer stoped
        {
            PlayersTurnText.gameObject.SetActive(false); // hide text
            playersSelection.EnablePlayerSelection(); // go to PlayersSelectionscript
            enabled = false;
        }
    }
}