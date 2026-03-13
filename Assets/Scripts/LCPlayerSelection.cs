using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LCPlayerSelection : MonoBehaviour
{
    public LCCombination combination;
    public LCSelectionManager selectionManager;

    public float displayDuration = 1f;
    private SpriteRenderer buttonLight;
    public bool isSelected = false;

    void Start()
    {
        buttonLight = GetComponent<SpriteRenderer>();

        if (buttonLight != null)
        {
            buttonLight.enabled = false; // starts hidden
        }
    }

    public void OnMouseDown()
    {
        if (!selectionManager.canSelect)
            return;

        selectionManager.AddToSelection(buttonLight);
    }
}
