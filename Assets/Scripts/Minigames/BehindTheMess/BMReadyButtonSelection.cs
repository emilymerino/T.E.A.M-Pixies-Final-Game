using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BMReadyButtonSelection : MonoBehaviour
{
    public BMInstructionsPopUp instructionsPopUp;
    public SpriteRenderer ReadyButton;
    public bool isSelected = false;

    void Start()
    {
        if (ReadyButton == null)
            ReadyButton = GetComponent<SpriteRenderer>();

        ReadyButton.gameObject.SetActive(false);
    }

    public void OnMouseDown()
    {
        if (CompareTag("Selectable"))
        {
            isSelected = true;
            Debug.Log("Button Selected");
            HideReadyButton();
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
        instructionsPopUp.HideInstructions();
    }
}
