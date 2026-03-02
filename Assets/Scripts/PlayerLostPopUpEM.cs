using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerLostPopUpEM : MonoBehaviour
{
    public float timeRemaining = 3f;
    public TextMeshProUGUI PlayerLost;

    void Start()
    {
        if (PlayerLost == null)
        {
            PlayerLost = GetComponent<TextMeshProUGUI>();
        }
        PlayerLost.gameObject.SetActive(false); // starts hidden
    }

    public void ShowLostPopUp()
    {
        PlayerLost.gameObject.SetActive(true); // show text
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
        }
    }
}
