using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BMLoveLetterClick : MonoBehaviour
{
    public bool canBeClicked = false;
    public string nextSceneName = "ThirdOutsideStudentCouncilInteractionScene";

    void OnMouseDown()
    {
        if (!canBeClicked) return;

        SceneManager.LoadScene(nextSceneName);
    }

    public void EnableLetterClick()
    {
        canBeClicked = true;
    }
}
