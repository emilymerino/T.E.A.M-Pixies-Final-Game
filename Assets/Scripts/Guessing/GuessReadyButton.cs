using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuessReadyButton : MonoBehaviour
{
    public GameObject guessingCanvas;
    public GameObject eloise;

    private ISHoverGlow hoverGlow;

    // Start is called before the first frame update
    private void Start()
    {
        hoverGlow = GetComponent<ISHoverGlow>();

        if (guessingCanvas != null)
        {
            guessingCanvas.SetActive(false);
            eloise.SetActive(true);
        }
    }

    private void OnMouseDown()
    {
        if (hoverGlow != null)
        {
            hoverGlow.HideGlow();
        }

        if (guessingCanvas != null)
        {
            guessingCanvas.SetActive(true);
            
        }

        gameObject.SetActive(false);
        eloise.SetActive(false);
    }
}
