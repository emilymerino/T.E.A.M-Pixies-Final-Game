using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BMLoveLetterClick : MonoBehaviour
{
    public bool canBeClicked = false;
    public string nextSceneName = "20-AfterBehindTheMess";

    private ISHoverGlow hoverGlow;
    public SpriteRenderer letterRenderer;

    void Start()
    {
        if (letterRenderer == null)
        {
            letterRenderer = GetComponent<SpriteRenderer>();
        }

        hoverGlow = GetComponent<ISHoverGlow>();
        if (hoverGlow != null)
        {
            hoverGlow.HideGlow();
        }

        if (letterRenderer != null)
        {
            letterRenderer.enabled = false;
        }
    }

    void OnMouseDown()
    {
        if (!canBeClicked) return;

        SceneManager.LoadScene(nextSceneName);
    }

    public void RevealLetter()
    {
        if (letterRenderer != null)
        {
            letterRenderer.enabled = true;
        }

        canBeClicked = true;
        Debug.Log("Love letter revealed and clickable");
    }
}
