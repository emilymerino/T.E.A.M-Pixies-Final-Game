using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IBLightFlickering : MonoBehaviour
{
    public SpriteRenderer Light1;
    public Sprite alertLight1;

    public SpriteRenderer Light2;
    public Sprite alertLight2;

    public float onTime = 0.1f;
    public float offTime = 0.1f;

    void Start()
    {
        Light1.sprite = alertLight1;
        StartCoroutine(Flicker1Loop());

        Light1.sprite = alertLight2;
    }

    IEnumerator Flicker1Loop()
    {
        while (true) // infinite loop
        {
            Light1.enabled = true;
            yield return new WaitForSeconds(onTime);

            StartCoroutine(Flicker2Loop());

            Light1.enabled = false;
            yield return new WaitForSeconds(offTime);
        }
    }

    IEnumerator Flicker2Loop()
    {
        while (true) // infinite loop
        {
            Light2.enabled = true;
            yield return new WaitForSeconds(onTime);

            Light2.enabled = false;
            yield return new WaitForSeconds(offTime);
        }
    }
}