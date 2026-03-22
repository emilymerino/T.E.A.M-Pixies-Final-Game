using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNGameOverAutoNext : MonoBehaviour
{
    [SerializeField] private float waitTime = 3f;

    private void OnEnable()
    {
        StartCoroutine(WaitAndLoad());
    }

    private IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(waitTime);

        SMMinigameAutoNext loader = FindObjectOfType<SMMinigameAutoNext>();

        if (loader != null )
        {
            loader.LoadNextScene();
        }
    }

}
