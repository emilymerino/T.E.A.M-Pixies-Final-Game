using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LCCombinationChecker : MonoBehaviour
{
    public LCSelectionManager selectionManager;
    public LCCombination combination;
    public LCLockBehaviour lockBehaviour;
    public LCLockUnlockedBehaviour lockUnlockedBehaviour;
    public LCGameGuideManager gameGuideManager;
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

        statusLightsBehaviour.ShowLockedStatusLights(3f);
        gameGuideManager.ShowNotQuite("Not quite, try again", 3f);

        selectionManager.canSelect = true;

        Debug.Log(debugMessage);
    }

    private void HandleSuccess()
    {
        combination.HideCombination();

        lockBehaviour.HideLock();
        lockUnlockedBehaviour.ShowLockUnlocked();

        gameGuideManager.HideInPlayInstructions();
        gameGuideManager.ShowYouGotIt();

        statusLightsBehaviour.ResetStatusLights();
        statusLightsBehaviour.ShowUnlockedStatusLights();

        selectionManager.canSelect = false;
    }
}