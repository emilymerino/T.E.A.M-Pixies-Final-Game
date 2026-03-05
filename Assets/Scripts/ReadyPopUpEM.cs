using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReadyPopUpEM : MonoBehaviour
{
    public BoardBehaviourEM boardBehaviourEM;
    public float timeRemaining = 2f;
    public TextMeshProUGUI Ready;

    void Start()
    {
        if (Ready == null)
        {
            Ready = GetComponent<TextMeshProUGUI>();
        }
        Ready.gameObject.SetActive(false); // starts hidden
    }

    public void ShowText()
    {
        Ready.gameObject.SetActive(true); // show text
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime; // decrease time
        }
        else // timer stoped
        {
            Ready.gameObject.SetActive(false); // hide text
            enabled = false;
            boardBehaviourEM.ShowBoard(); // go to BoardBehaviour script
            boardBehaviourEM.ShowShapes(); // go to BoardBehaviour script
        }
    }
}
