using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IBSceneChange : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("TornNoteScene");
    }
}

