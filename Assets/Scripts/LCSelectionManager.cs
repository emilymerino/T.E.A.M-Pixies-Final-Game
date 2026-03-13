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
        if (!canSelect) return;

        if (currentButtonLight != null) // turn off previous button light
        {
            currentButtonLight.enabled = false;
        }

        // set new light
        currentButtonLight = buttonLight;
        currentButtonLight.enabled = true;

        playersSelection.Add(buttonLight); // allow duplicates
        Debug.Log(buttonLight.gameObject.name + " added to list.");
        statusLightsBehaviour.ShowStatusLights();

        if (playersSelection.Count >= maxSelections)
        {
            Debug.Log("Maximum selections reached");

             StartCoroutine(CompareAfterDelay());
        }
    }

    IEnumerator CompareAfterDelay()
    {
        yield return new WaitForSeconds(2f); // keep last light on for 2 seconds

        combinationChecker.CompareCombinations(
            combinationChecker.combination.combinationList,
            playersSelection
        );
    }
}

