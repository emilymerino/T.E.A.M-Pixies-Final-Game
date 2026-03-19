using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SWHoverGlow : MonoBehaviour
{
    public SpriteRenderer Sprite;

    void Start()
    {
        Sprite.gameObject.SetActive(false); // starts hidden
    }

    void OnMouseEnter()
    {
        Sprite.gameObject.SetActive(true);
        Debug.Log("Enter");
    }

    void OnMouseExit()
    {
        Sprite.gameObject.SetActive(false);
        Debug.Log("Exit");
    }
}
