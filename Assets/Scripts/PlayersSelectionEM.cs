using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersSelectionEM : MonoBehaviour
{
    public MatchCheckerEM matchCheckerEM;

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
            return;
        }

        isSelected = !isSelected; // flips value

        if (isSelected)
        {
            spriteRenderer.sprite = selectedShape;
            selectedCount++;
            matchCheckerEM.SelectShape(gameObject);
            Debug.Log("Selected !");
        }
        else
        {
            spriteRenderer.sprite = shape;
            selectedCount--;
            matchCheckerEM.DeselectShape(gameObject);
            Debug.Log("Deselected !");
        }
    }

    public void RemoveShape()
    {
        Destroy(gameObject);
    }

    public void ForceDeselect()
    {
        if (isSelected)
        {
            isSelected = false;
            spriteRenderer.sprite = shape;
            selectedCount--;
            canSelect = true;
        }
        canSelect = true;
    }
}
