using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

<<<<<<<< HEAD:Assets/Scripts/LCClueUnlockedPopUp.cs
public class LCClueUnlockedPopUp : MonoBehaviour
========
public class BMClueUnlocked : MonoBehaviour
>>>>>>>> 8a5f27bc14d4882fc6f8b33770e4727e7df4bd0c:Assets/Scripts/BMClueUnlocked.cs
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
