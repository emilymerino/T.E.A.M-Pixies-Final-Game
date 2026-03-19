using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SWLighteningBehaviour : MonoBehaviour
{
    public SpriteRenderer Lightening;
    public Sprite alertLightening;

    public void Start()
    {
        Lightening.enabled = false;
        ShowLightening(alertLightening, 3f);
    }

    public void ShowLightening(Sprite image, float delay)
    {
        StopAllCoroutines();
        StartCoroutine(ShowSpriteRoutine(image, delay));
    }

    private IEnumerator ShowSpriteRoutine(Sprite image, float delay)
    {
        yield return new WaitForSeconds(delay);

        Lightening.sprite = image;
        Lightening.enabled = true; // stay on
        HideLightening(alertLightening, 0.1f);
    }

    public void HideLightening(Sprite image, float duration)
    {
        StopAllCoroutines();
        StartCoroutine(ShowSprite2Routine(image, duration));
    }

    private IEnumerator ShowSprite2Routine(Sprite image, float duration)
    {
        yield return new WaitForSeconds(duration); // wait for certain time

        Lightening.sprite = image;
        Lightening.enabled = false; // stay off
    }
}
