using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LCSelectionManager : MonoBehaviour
{
    public List<SpriteRenderer> playersSelection = new List<SpriteRenderer>();

    public bool canSelect = false;

    public void AddToSelection(SpriteRenderer light)
    {
        if (!playersSelection.Contains(light))
        {
            playersSelection.Add(light);
            Debug.Log(light.gameObject.name + " added to list.");
        }
    }

    public void RemoveFromSelection(SpriteRenderer light)
    {
        if (playersSelection.Contains(light))
        {
            playersSelection.Remove(light);
            Debug.Log(light.gameObject.name + " removed from list.");
        }
    }
}

