using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BMGameStartController : MonoBehaviour
{
    public GameObject gameRoot;

    // Start is called before the first frame update
    public void Start()
    {
        if (gameRoot != null)
        {
            gameRoot.SetActive(false);
        }
    }

    public void StartMinigame()
    {
        if (gameRoot != null)
        {
            gameRoot.SetActive(true);
        }
    }
}
