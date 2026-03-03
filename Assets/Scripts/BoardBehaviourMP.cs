using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardBehaviourMP : MonoBehaviour
{
    public List<GameObject> border; // list of squares to form minigame border

    void Start()
    {
        foreach (GameObject square in border)
        {
            square.SetActive(false);
        }
    }

    public void ShowBorder()
    {
        foreach (GameObject square in border)
        {
            square.SetActive(true);
        }
    }

    public void HideBorder()
    {
        foreach (GameObject square in border)
        {
            square.SetActive(false);
        }
    }
}
