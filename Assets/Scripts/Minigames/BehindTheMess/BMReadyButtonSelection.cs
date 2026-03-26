using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BMReadyButtonSelection : MonoBehaviour
{
    public BMInstructionsPopUp instructionsPopUp;
    public BMGameStartController gameStartController;
    
    private ISHoverGlow hoverGlow;
    public SpriteRenderer ReadyButton;
    
    public bool isSelected = false;

    void Start()
    {
        if (ReadyButton == null)
            ReadyButton = GetComponent<SpriteRenderer>();

        hoverGlow = GetComponent<ISHoverGlow>();
        if (hoverGlow != null)
        {
            hoverGlow.HideGlow();
        }

        ReadyButton.gameObject.SetActive(false);
    }

    public void OnMouseDown()
    {
        if (CompareTag("Selectable"))
        {
            isSelected = true;

            if (hoverGlow != null)
            {
                hoverGlow.HideGlow();
            }

            Debug.Log("Button Selected");
            HideReadyButton();
            gameStartController.StartMinigame();
        }
    }

    public void ShowReadyButton()
    {
        ReadyButton.gameObject.SetActive(true);
        Debug.Log("Button Shown");
    }

    public void HideReadyButton()
    {
        ReadyButton.gameObject.SetActive(false);
        Debug.Log("Button Hidden");

        if (hoverGlow != null)
        {
            hoverGlow.HideGlow();
        }

        if (instructionsPopUp != null)
        {
            instructionsPopUp.HideInstructions();
        }
    }
}
