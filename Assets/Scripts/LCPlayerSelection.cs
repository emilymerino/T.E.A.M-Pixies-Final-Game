using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LCPlayerSelection : MonoBehaviour
{
    public LCCombination combination;
    public LCSelectionManager selectionManager;

    public float displayDuration = 1f;
    private SpriteRenderer light;
    private bool isSelected = false;

    void Start()
    {
        light = GetComponent<SpriteRenderer>();

        if (light != null)
        {
            light.enabled = false; // starts hidden
        }
    }

    public void OnMouseDown()
    {
        if (!selectionManager.canSelect)
            return;

        isSelected = !isSelected; // Toggle selection state

        if (isSelected)
        {
            selectionManager.AddToSelection(light);
            light.enabled = true;
        }
        else
        {
            selectionManager.RemoveFromSelection(light);
            light.enabled = false;
        }
    }
}
