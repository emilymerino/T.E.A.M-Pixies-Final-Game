using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LCSelectionManager : MonoBehaviour
{
    public List<SpriteRenderer> playersSelection = new List<SpriteRenderer>();

    private SpriteRenderer currentLight;
    public bool canSelect = false;

    public void AddToSelection(SpriteRenderer light)
    {
        if (!canSelect) return;

        if (currentLight != null) // turn off previous light
        {
            currentLight.enabled = false;
        }

        // set new light
        currentLight = light;
        currentLight.enabled = true;

        playersSelection.Add(light); // allow duplicates
        Debug.Log(light.gameObject.name + " added to list.");
    }
}

