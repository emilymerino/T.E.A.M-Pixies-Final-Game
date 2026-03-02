using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReadyPopUpMP : MonoBehaviour
{
    public PlayersSelectionMP playersSelectionMP;
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
            playersSelectionMP.EnablePlayerSelection(); // go to PlayersSelectionscript
            enabled = false;
        }
    }
}