using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LCCombination : MonoBehaviour
{
    public LCSelectionManager selectionManager;
    public LCPlayerSelection playerSelection;
    public LCSubmitButtonSelection submitButtonSelection;

    public List<SpriteRenderer> combinationList;
    public List<SpriteRenderer> notCombinationList;

    private int currentIndex = 0;
    public float displayDuration = 1f;

    void Start()
    {
        if (combinationList == null) return;

        foreach (SpriteRenderer light in combinationList)
        {
            if (light != null)
            {
                light.enabled = false; // starts hidden
            }
        }
        StartCoroutine(DelayAction(2.0f));
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
            foreach (SpriteRenderer light in combinationList)
            {
                if (light != null)
                {
                    light.enabled = false; // starts hidden
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
        selectionManager.canSelect = true; // enable clicks 
    }

    public void HideCombination()
    {
        foreach (SpriteRenderer light in combinationList)
        {
            if (light != null)
            {
                light.enabled = false;
                submitButtonSelection.ShowSubmitButton();
                selectionManager.playersSelection.Clear();
            }
        }
    }

    public void HideNotCombinationList()
    {
        foreach (SpriteRenderer light in notCombinationList)
        {
            if (light != null)
            {
                light.enabled = false;
                selectionManager.playersSelection.Clear();
            }
        }
    }
}
