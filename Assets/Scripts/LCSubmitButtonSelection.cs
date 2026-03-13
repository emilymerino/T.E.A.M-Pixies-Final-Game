using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LCSubmitButtonSelection : MonoBehaviour
{
    public LCCombinationChecker combinationChecker;

    public SpriteRenderer SubmitButton;
    public bool isSelected = false;

    void Start()
    {
        if (SubmitButton == null)
        {
            SubmitButton = GetComponent<SpriteRenderer>();
        }
        SubmitButton.gameObject.SetActive(false);
    }

    public void OnMouseDown()
    {
        if (CompareTag("Selectable"))
        {
            isSelected = true;
            Debug.Log("Button Selected");

            bool result = combinationChecker.CompareCombinations(
            combinationChecker.combination.combinationList,
            combinationChecker.selectionManager.playersSelection
        );
        }
    }

    public void ShowSubmitButton()
    {
        SubmitButton.gameObject.SetActive(true);
        Debug.Log("Button Shown");
    }

    public void HideSubmitButton()
    {
        SubmitButton.gameObject.SetActive(false);
        Debug.Log("Button Hidden");
    }
}
