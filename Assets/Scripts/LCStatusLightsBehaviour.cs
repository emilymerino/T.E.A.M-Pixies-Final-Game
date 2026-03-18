using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LCStatusLightsBehaviour : MonoBehaviour
{
    public LCSelectionManager selectionManager;

    public List<SpriteRenderer> statusLightsList;
    public List<SpriteRenderer> unlockedStatusLightsList;
    //public List<SpriteRenderer> lockedStatusLightsList;

    [SerializeField] private List<SpriteRenderer> lockedStatusLightsList;

    private int currentIndex = 0;

    void Start()
    {
        if (statusLightsList != null)
        {
            foreach (SpriteRenderer statusLight in statusLightsList)
            {
                if (statusLight != null)
                    statusLight.enabled = false;
            }
        }

        if (unlockedStatusLightsList != null)
        {
            foreach (SpriteRenderer uStatusLight in unlockedStatusLightsList)
            {
                if (uStatusLight != null)
                    uStatusLight.enabled = false;
            }
        }

        if (lockedStatusLightsList != null)
        {
            foreach (SpriteRenderer lStatusLight in lockedStatusLightsList)
            {
                if (lStatusLight != null)
                    lStatusLight.enabled = false;
            }
        }
    }

    public void ShowStatusLights()
    {
        for (int i = 0; i < statusLightsList.Count; i++)
        {
            statusLightsList[currentIndex].enabled = true; // show current sprite
        }
        currentIndex++;

        if (currentIndex >= statusLightsList.Count)
        {
            currentIndex = 0;
        }
    }

    public void HideStatusLights()
    {
        foreach (SpriteRenderer statusLight in statusLightsList)
        {
            if (statusLight != null)
            {
                statusLight.enabled = false;
                selectionManager.playersSelection.Clear();
            }
        }
    }

    public void ShowUnlockedStatusLights()
    {
        for (int i = 0; i < unlockedStatusLightsList.Count; i++)
        {
            unlockedStatusLightsList[i].enabled = true; // show current sprite
        }
    }

    public void ShowLockedStatusLights(float duration)
    {
        StopAllCoroutines();
        StartCoroutine(ShowlockedLightsRoutine(duration));
    }

    private IEnumerator ShowlockedLightsRoutine(float duration)
    {
        foreach (SpriteRenderer lStatusLight in lockedStatusLightsList)
        {
            if (lStatusLight != null)
            {
                lStatusLight.enabled = true;
            }
        }

        yield return new WaitForSeconds(duration);

        foreach (SpriteRenderer light in lockedStatusLightsList)
        {
            if (light != null)
            {
                light.enabled = false;
            }
        }
    }
}
