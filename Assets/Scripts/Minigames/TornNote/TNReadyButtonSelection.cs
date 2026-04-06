using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNReadyButtonSelection : MonoBehaviour
{
    public GameObject instructionsTitle;
    public GameObject instructionsBody;

    public GameObject puzzleRoot;

    private ISHoverGlow hoverGlow;
    private SpriteRenderer ReadyButton;

    public bool isSelected = false;

    void Start()
    {
        ReadyButton = GetComponent<SpriteRenderer>();
        hoverGlow = GetComponent<ISHoverGlow>();

        ReadyButton.enabled = false;
    }

    void OnMouseDown()
    {
        if (CompareTag("Selectable"))
        {
            isSelected = true;
            Debug.Log("Button Selected");
            HideReadyButton();

            if (puzzleRoot != null)
            {
                puzzleRoot.SetActive(true);
            }
        }
    }

    public void ShowReadyButton()
    {
        ReadyButton.enabled = true;
        Debug.Log("Button Shown");
    }

    public void HideReadyButton()
    {
        ReadyButton.enabled = false;

        if (hoverGlow != null)
        {
            hoverGlow.HideGlow();
        }

        if (instructionsTitle != null)
        {
            instructionsTitle.SetActive(false);
        }

        if (instructionsBody != null)
        {
            instructionsBody.SetActive(false);
        }

        Debug.Log("Button Hidden");
    }
}