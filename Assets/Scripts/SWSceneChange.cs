using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SWSceneChange : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("ClassroomInteractionScene");
    }
}

