using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuessReadyButton : MonoBehaviour
{
    public GameObject guessingCanvas;

    private ISHoverGlow hoverGlow;

    // Start is called before the first frame update
    private void Start()
    {
        hoverGlow = GetComponent<ISHoverGlow>();

        if (guessingCanvas != null)
        {
            guessingCanvas.SetActive(false);
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
    }
}
