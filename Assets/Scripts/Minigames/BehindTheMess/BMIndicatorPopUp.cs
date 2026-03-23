using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BMIndicatorPopUp : MonoBehaviour
{
    public SpriteRenderer Indicator;
    public Sprite alertIndicator;

    void Start()
    {
        Indicator.enabled = false;
    }

    public void ShowIndicator(Sprite image, float delay)
    {
        StopAllCoroutines();
        StartCoroutine(ShowSpriteRoutine(image, delay));
    }

    private IEnumerator ShowSpriteRoutine(Sprite image, float delay)
    {
        yield return new WaitForSeconds(delay);

        Indicator.sprite = image;
        Indicator.enabled = true; // stay on
    }
}
