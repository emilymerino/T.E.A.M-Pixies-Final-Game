using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersSelectionEM : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite selectedShape;
    public Sprite shape;
    private int maxSelectedShapes = 2;
    private static int selectedCount = 0;

    private bool isSelected = false;
    public bool canSelect = true;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = shape;
    }
    void OnMouseDown()
    {
        if (!canSelect) return;
        if (!CompareTag("Selectable")) return;

        if (!isSelected && selectedCount == maxSelectedShapes) // prevent selecting more than max allowed shapes
        {
            Debug.Log("Max Selected");
            return;
        }

        isSelected = !isSelected; // flips value

        if (selectedCount < maxSelectedShapes)
        {
            if (isSelected)
            {
                spriteRenderer.sprite = selectedShape;
                selectedCount++;
                Debug.Log("Selected " + gameObject.name);
            }
            else
            {
                spriteRenderer.sprite = shape;
                selectedCount--;
                Debug.Log("Deselected " + gameObject.name);
            }
            Debug.Log("Selected " + selectedCount);
        }
    }
}
