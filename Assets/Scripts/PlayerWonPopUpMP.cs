using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerWonPopUpMP : MonoBehaviour
{
    public float timeRemaining = 2f;
    public TextMeshProUGUI PlayerWon;

    void Start()
    {
        if (PlayerWon == null)
        {
            PlayerWon = GetComponent<TextMeshProUGUI>();
        }
        PlayerWon.gameObject.SetActive(false); // starts hidden
    }

    public void ShowWonPopUp()
    {
        PlayerWon.gameObject.SetActive(true); // show text
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
        }
    }
}
