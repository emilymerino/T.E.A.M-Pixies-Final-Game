using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationsHoverGlow : MonoBehaviour
{
    public SpriteRenderer Sprite;

    void Start()
    {
        Sprite.gameObject.SetActive(false);
    }

    void OnMouseEnter()
    {
        if (FirstConversationsDialogue.isTalking) return;

        Sprite.gameObject.SetActive(true);
    }

    void OnMouseExit()
    {
        Sprite.gameObject.SetActive(false);
    }
}
