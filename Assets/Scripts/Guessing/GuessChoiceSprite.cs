using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuessChoiceSprite : MonoBehaviour
{
    public bool isCorrectChoice;
    public string correctSceneName;
    public string wrongSceneName;

    private void OnMouseDown()
    {
        if (isCorrectChoice)
        {
            SceneManager.LoadScene(correctSceneName);
        }
        else
        {
            SceneManager.LoadScene(wrongSceneName);
        }
    }
}
