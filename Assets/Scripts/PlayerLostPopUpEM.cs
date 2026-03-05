using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerLostPopUpEM : MonoBehaviour
{
    public float timeRemaining = 2f;
    public TextMeshProUGUI PlayerLost;

    private SMMinigameAutoNext sceneAutoNext;

    void Start()
    {
        if (PlayerLost == null)
        {
            PlayerLost = GetComponent<TextMeshProUGUI>();
        }
        PlayerLost.gameObject.SetActive(false); // starts hidden
        enabled = false;

        sceneAutoNext = FindObjectOfType<SMMinigameAutoNext>();
    }

    public void ShowLostPopUp()
    {
        PlayerLost.gameObject.SetActive(true); // show text
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
            PlayerLost.gameObject.SetActive(false); // hide text
            enabled = false;

            if (sceneAutoNext != null)
                sceneAutoNext.LoadNextScene();
        }
    }
}
