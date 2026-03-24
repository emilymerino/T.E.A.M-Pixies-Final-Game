using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SWLighteningBehaviour : MonoBehaviour
{
    public SpriteRenderer Lightening;
    public Sprite alertLightening;

    public float loopDelay = 4f;     // time between flashes
    public float flashDuration = 0.1f; // how long it stays visible

    void Start()
    {
        Lightening.enabled = false;
        StartCoroutine(LightningLoop());
    }

    private IEnumerator LightningLoop()
    {
        while (true) // infinite loop
        {
            yield return new WaitForSeconds(loopDelay);

            // show
            Lightening.sprite = alertLightening;
            Lightening.enabled = true;

            yield return new WaitForSeconds(flashDuration);

            // hide
            Lightening.enabled = false;
        }
    }
}