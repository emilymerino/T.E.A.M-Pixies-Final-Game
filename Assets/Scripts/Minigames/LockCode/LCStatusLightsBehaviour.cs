using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LCStatusLightsBehaviour : MonoBehaviour
{
    public LCSelectionManager selectionManager;

    public List<SpriteRenderer> statusLightsList;
    public List<SpriteRenderer> unlockedStatusLightsList;

    [SerializeField] private List<SpriteRenderer> lockedStatusLightsList;

    public bool isLockedShowing = false;

    private int currentIndex = 0;

    void Start()
    {
        TurnOffList(statusLightsList);
        TurnOffList(unlockedStatusLightsList);
        TurnOffList(lockedStatusLightsList);
    }

    void TurnOffList(List<SpriteRenderer> list)
    {
        if (list == null) return;

        foreach (SpriteRenderer light in list)
        {
            if (light != null)
                light.enabled = false;
        }
    }

    public void ShowStatusLights()
    {
        if (currentIndex < statusLightsList.Count)
        {
            statusLightsList[currentIndex].enabled = true;
            currentIndex++;
        }
    }

    public void HideStatusLights()
    {
        foreach (SpriteRenderer light in statusLightsList)
        {
            if (light != null)
                light.enabled = false;
        }

        selectionManager.playersSelection.Clear();
    }

    public void ShowUnlockedStatusLights()
    {
        foreach (SpriteRenderer light in unlockedStatusLightsList)
        {
            if (light != null)
                light.enabled = true;
        }
    }

    public void ShowLockedStatusLights(float duration)
    {
        StopAllCoroutines();
        StartCoroutine(ShowLockedLightsRoutine(duration));
    }

    private IEnumerator ShowLockedLightsRoutine(float duration)
    {
        isLockedShowing = true;

        // block input
        if (selectionManager != null)
            selectionManager.canSelect = false;

        foreach (SpriteRenderer light in lockedStatusLightsList)
        {
            if (light != null)
                light.enabled = true;
        }

        yield return new WaitForSeconds(duration);

        foreach (SpriteRenderer light in lockedStatusLightsList)
        {
            if (light != null)
                light.enabled = false;
        }

        // unlock
        isLockedShowing = false;

        // allow selection again after lock is gone
        if (selectionManager != null)
            selectionManager.canSelect = true;
    }

    public void ResetStatusLights()
    {
        TurnOffList(statusLightsList);
        TurnOffList(unlockedStatusLightsList);
        TurnOffList(lockedStatusLightsList);

        currentIndex = 0;

        selectionManager.playersSelection.Clear();
    }
}