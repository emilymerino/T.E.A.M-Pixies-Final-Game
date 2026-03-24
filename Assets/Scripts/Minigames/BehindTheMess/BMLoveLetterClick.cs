using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BMLoveLetterClick : MonoBehaviour
{
    public bool canBeClicked = false;
    public string nextSceneName = "ThirdOutsideStudentCouncilInteractionScene";
    public SpriteRenderer letterRenderer;

    void Start()
    {
        if (letterRenderer == null)
        {
            letterRenderer = GetComponent<SpriteRenderer>();
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
