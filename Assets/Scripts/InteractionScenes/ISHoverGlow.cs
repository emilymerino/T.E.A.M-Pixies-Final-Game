using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ISHoverGlow : MonoBehaviour
{
    public SpriteRenderer glowSprite;
    private SpriteRenderer buttonSprite;
    private Collider2D buttonCollider;

    void Start()
    {
        buttonSprite = GetComponent<SpriteRenderer>();
        buttonCollider = GetComponent<Collider2D>();

        if (glowSprite != null)
        {
            glowSprite.enabled = false;
        }
    }

    void Update()
    {
        if (glowSprite == null || buttonSprite == null || buttonCollider == null)
            return;

        if (!buttonSprite.enabled)
        {
            glowSprite.enabled = false;
            return;
        }

        Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (buttonCollider.OverlapPoint(mouseWorldPos))
        {
            glowSprite.enabled = true;
        }
        else
        {
            glowSprite.enabled = false;
        }
    }

    public void HideGlow()
    {
        if (glowSprite != null)
        {
            glowSprite.enabled = false;
        }

    }
}