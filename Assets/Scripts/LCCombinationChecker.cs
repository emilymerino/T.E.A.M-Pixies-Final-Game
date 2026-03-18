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
            combination.HideCombination();
            combination.HideNotCombinationList();
            statusLightsBehaviour.HideStatusLights();
            statusLightsBehaviour.ShowLockedStatusLights(3f);
            gameGuideManager.ShowNotQuite("Not quite, try again", 3f);
            Debug.Log("Lists are different lengths");
            return false;
        }

        for (int i = 0; i < combinationList.Count; i++)
        {
            if (combinationList[i] != playersSelection[i])
            {
                combination.HideCombination();
                combination.HideNotCombinationList();
                statusLightsBehaviour.HideStatusLights();
                statusLightsBehaviour.ShowLockedStatusLights(3f);
                gameGuideManager.ShowNotQuite("Not quite, try again", 3f);
                Debug.Log("Lists are not the same");
                return false;
            }
        }
        combination.HideCombination();
        lockBehaviour.HideLock();
        lockUnlockedBehaviour.ShowLockUnlocked();
        gameGuideManager.HideInPlayInstructions();
        statusLightsBehaviour.HideStatusLights();
        gameGuideManager.ShowYouGotIt();
        Debug.Log("Lists are the same");
        return true;
    }

    public void ClearSelection()
    {
        //selectionManager.playersSelection.Clear();
    }
}
