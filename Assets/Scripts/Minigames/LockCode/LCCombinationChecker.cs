using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LCCombinationChecker : MonoBehaviour
{
    public LCSelectionManager selectionManager;
    public LCCombination combination;
    public LCLockBehaviour lockBehaviour;
    public LCLockUnlockedBehaviour lockUnlockedBehaviour;
    public LCStatusLightsBehaviour statusLightsBehaviour;

    public bool CompareCombinations(List<SpriteRenderer> combinationList, List<SpriteRenderer> playersSelection)
    {
        if (combinationList == null || playersSelection == null)
        {
            return false;
        }

        if (combinationList.Count != playersSelection.Count)
        {
            HandleFailure("Lists are different lengths");
            return false;
        }

        for (int i = 0; i < combinationList.Count; i++)
        {
            if (combinationList[i] != playersSelection[i])
            {
                HandleFailure("Lists are not the same");
                return false;
            }
        }

        HandleSuccess();
        return true;
    }

    private void HandleFailure(string debugMessage)
    {
        combination.HideCombination();
        combination.HideNotCombinationList();

        statusLightsBehaviour.ResetStatusLights();
        statusLightsBehaviour.ShowLockedStatusLights(2f);

        selectionManager.canSelect = false;

        Debug.Log(debugMessage);

        // replay combination after delay
        StartCoroutine(ReplayAfterDelay());
    }

    IEnumerator ReplayAfterDelay()
    {
        yield return new WaitForSeconds(2f);

        combination.PlayCombination();
    }

    private void HandleSuccess()
    {
        combination.HideCombination();

        lockBehaviour.HideLock();
        lockUnlockedBehaviour.ShowLockUnlocked();

        statusLightsBehaviour.ResetStatusLights();
        statusLightsBehaviour.ShowUnlockedStatusLights();

        selectionManager.canSelect = false;
    }
}