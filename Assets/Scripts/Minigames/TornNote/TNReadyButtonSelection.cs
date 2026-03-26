using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNReadyButtonSelection : MonoBehaviour
{
    public TNAutoHideAfterSeconds readyPopUp;

    public GameObject instructionsTitle;
    public GameObject instructionsBody;

    private SpriteRenderer ReadyButton;

    public bool isSelected = false;

    void Start()
    {
        ReadyButton = GetComponent<SpriteRenderer>();
        ReadyButton.enabled = false;
    }

    void OnMouseDown()
    {
        if (CompareTag("Selectable"))
        {
            isSelected = true;
            Debug.Log("Button Selected");
            HideReadyButton();

            if (readyPopUp != null)
            {
                readyPopUp.HideObject(); // show ready popup
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