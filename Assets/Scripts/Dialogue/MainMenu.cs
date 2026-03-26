using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public UIHoverGlow hoverGlow;

    public void GameStart()
    {
        if (hoverGlow != null)
        {
            hoverGlow.HideGlow();
        }

        SceneManager.LoadSceneAsync("2-Outside");
    }

    public void GameQuit()
    {
        Application.Quit();
    }
}
