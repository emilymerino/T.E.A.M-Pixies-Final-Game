using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuessReadyButton : MonoBehaviour
{
    public GameObject guessingCanvas;

    // Start is called before the first frame update
    private void Start()
    {
        if (guessingCanvas != null)
        {
            guessingCanvas.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        if (guessingCanvas != null)
        {
            guessingCanvas.SetActive(true);
        }

        gameObject.SetActive(false);
    }
}
