using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIHoverGlow : MonoBehaviour,  IPointerEnterHandler, IPointerExitHandler
{
    public SpriteRenderer glowSprite;

    // Start is called before the first frame update
    void Start()
    {
        if (glowSprite != null)
        {
            glowSprite.enabled = false;
        }

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (glowSprite != null)
        {
            glowSprite.enabled = true;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (glowSprite != null)
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
