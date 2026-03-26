using UnityEngine;

public class ISHoverGlow : MonoBehaviour
{
    public SpriteRenderer Sprite;

    void Start()
    {
        Sprite.gameObject.SetActive(false); // starts hidden
    }

    void OnMouseEnter()
    {
        // ❌ don't glow while talking
        if (FirstConversationsDialogue.isTalking) return;

        Sprite.gameObject.SetActive(true);
        Debug.Log("Enter");
    }

    void OnMouseExit()
    {
        Sprite.gameObject.SetActive(false);
        Debug.Log("Exit");
    }
}