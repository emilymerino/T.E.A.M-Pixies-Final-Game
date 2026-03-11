using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BMGameOverPopUp : MonoBehaviour
{
    public float timeRemaining = 3f;
    public TextMeshProUGUI GameOver;

    void Start()
    {
        if (GameOver == null)
        {
            GameOver = GetComponent<TextMeshProUGUI>();
        }
        GameOver.gameObject.SetActive(false); // starts hidden
    }

    public void ShowGameOver()
    {
        GameOver.gameObject.SetActive(true); // show text
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime; // decrease time
        }
        else // timer stoped
        {
            GameOver.gameObject.SetActive(false); // hide text
            enabled = false;
        }
    }
}
