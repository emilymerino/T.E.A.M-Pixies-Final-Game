using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RecievedCluePopUp : MonoBehaviour
{
    public float timeRemaining = 10f;
    public TextMeshProUGUI Clue;

    void Start()
    {
        if (Clue == null)
        {
            Clue = GetComponent<TextMeshProUGUI>();
        }
        Clue.gameObject.SetActive(false); // starts hidden
    }

    public void ShowClue()
    {
        Clue.gameObject.SetActive(true); // show text
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime; // decrease time
        }
        else // timer stoped
        {
            Clue.gameObject.SetActive(false); // hide text
            enabled = false;
        }
    }
}
