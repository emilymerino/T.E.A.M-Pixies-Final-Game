using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LCCombination : MonoBehaviour
{
    public LCSelectionManager selectionManager;
    public LCPlayerSelection playerSelection;
    public LCViewCombinationButton viewCombinationButton;
    public LCStatusLightsBehaviour statusLightsBehaviour;

    public List<SpriteRenderer> combinationList;
    public List<SpriteRenderer> notCombinationList;

    private int currentIndex = 0;
    public float displayDuration = 1f;

    public void PlayCombination()
    {
        StopAllCoroutines();
        currentIndex = 0;
        selectionManager.canSelect = false;

        if (statusLightsBehaviour != null)
        {
            statusLightsBehaviour.ResetStatusLights();
        }
        HideNotCombinationList();
        selectionManager.playersSelection.Clear();
        StartCoroutine(ShowCombination());
    }

    public IEnumerator DelayAction(float delayTime)
    {
        yield return new WaitForSeconds(delayTime); // wait for 2 seconds
        StartCoroutine(ShowCombination());
        Debug.Log("Action executed after delay!");
    }

    public IEnumerator ShowCombination()
    {
        for (int i = 0; i < combinationList.Count; i++)
        {
            foreach (SpriteRenderer buttonLight in combinationList)
            {
                if (buttonLight != null)
                {
                    buttonLight.enabled = false; // starts hidden
                }
            }

            combinationList[currentIndex].enabled = true; // show current sprite

            yield return new WaitForSeconds(displayDuration); // wait for specific duration before moving to next sprite

            currentIndex++;

            if (currentIndex >= combinationList.Count)
            {
                currentIndex = 0;
            }
        }
        HideCombination(); // makes sures combination hidden after shown
        viewCombinationButton.ShowViewCombinationButton();
        selectionManager.canSelect = true; // enable clicks 
    }

    public void HideCombination()
    {
        foreach (SpriteRenderer buttonLight in combinationList)
        {
            if (buttonLight != null)
            {
                buttonLight.enabled = false;
                selectionManager.playersSelection.Clear();
            }
        }
    }

    public void HideNotCombinationList()
    {
        foreach (SpriteRenderer buttonLight in notCombinationList)
        {
            if (buttonLight != null)
            {
                buttonLight.enabled = false;
                selectionManager.playersSelection.Clear();
            }
        }
    }
}
