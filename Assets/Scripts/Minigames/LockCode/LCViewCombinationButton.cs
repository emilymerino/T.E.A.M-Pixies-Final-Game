using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LCViewCombinationButton : MonoBehaviour
{
    public LCCombination combination;

    public SpriteRenderer ViewCombinationButton;
    public bool isSelected = false;

    void Start()
    {
        if (ViewCombinationButton == null)
        {
            ViewCombinationButton = GetComponent<SpriteRenderer>();
        }
        ViewCombinationButton.gameObject.SetActive(false);
    }

    public void OnMouseDown()
    {
        if (CompareTag("Selectable"))
        {
            isSelected = true;

            combination.PlayCombination();

            Debug.Log("Button Selected");
        }
    }

    public void ShowViewCombinationButton()
    {
        ViewCombinationButton.gameObject.SetActive(true);
        Debug.Log("Button Shown");
    }

    public void HideReadyButton()
    {
        ViewCombinationButton.gameObject.SetActive(false);
        Debug.Log("Button Hidden");
    }
}
