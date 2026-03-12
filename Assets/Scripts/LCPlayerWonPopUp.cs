using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LCPlayerWonPopUp : MonoBehaviour
{
    public float timeRemaining = 2f;
    public TextMeshProUGUI PlayerWon;

    private SMMinigameAutoNext sceneAutoNext;

    void Start()
    {
        if (PlayerWon == null)
        {
            PlayerWon = GetComponent<TextMeshProUGUI>();
        }
        PlayerWon.gameObject.SetActive(false); // starts hidden
        enabled = false;

        sceneAutoNext = FindObjectOfType<SMMinigameAutoNext>();
    }

    public void ShowWonPopUp()
    {
        PlayerWon.gameObject.SetActive(true); // show text
        timeRemaining = 2f;
        enabled = true;
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime; // decrease time
        }
        else // timer stoped
        {
            PlayerWon.gameObject.SetActive(false); // hide text
            enabled = false;

            if (sceneAutoNext != null)
                sceneAutoNext.LoadNextScene();
        }
    }
}
