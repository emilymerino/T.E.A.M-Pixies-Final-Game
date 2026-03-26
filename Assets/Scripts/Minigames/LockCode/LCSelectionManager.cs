using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LCSelectionManager : MonoBehaviour
{
    public LCCombinationChecker combinationChecker;
    public LCStatusLightsBehaviour statusLightsBehaviour;

    public List<SpriteRenderer> playersSelection = new List<SpriteRenderer>();

    private SpriteRenderer currentButtonLight;
    public int maxSelections = 6;
    public bool canSelect = false;

    public void AddToSelection(SpriteRenderer buttonLight)
    {
        if (!canSelect || statusLightsBehaviour.isLockedShowing || playersSelection.Count >= maxSelections)
            return;

        // turn off previous light
        if (currentButtonLight != null)
            currentButtonLight.enabled = false;

        // set new light
        currentButtonLight = buttonLight;
        currentButtonLight.enabled = true;

        playersSelection.Add(buttonLight);
        Debug.Log(buttonLight.gameObject.name + " added.");

        statusLightsBehaviour.ShowStatusLights();

        // reached max, lock input
        if (playersSelection.Count == maxSelections)
        {
            Debug.Log("Max selections reached");

            canSelect = false;

            StartCoroutine(CompareAfterDelay());
        }
    }

    IEnumerator CompareAfterDelay()
    {
        yield return new WaitForSeconds(2f);

        combinationChecker.CompareCombinations(
            combinationChecker.combination.combinationList,
            playersSelection
        );
    }
}