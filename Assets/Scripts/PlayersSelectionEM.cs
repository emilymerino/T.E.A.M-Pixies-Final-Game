using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersSelectionEM : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite clickedShape;
    public Sprite shape;

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

        isSelected = !isSelected; // flips value

        if (isSelected)
        {
            spriteRenderer.sprite = clickedShape;
            Debug.Log("Selected " + gameObject.name);
        }
        else
        {
            spriteRenderer.sprite = shape;
            Debug.Log("Deselected " + gameObject.name);
        }
    }
}
