using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SMMinigameAutoNext : MonoBehaviour
{
    [SerializeField] private string nextSceneName;
    [SerializeField] private float delayBeforeLoading = 2f;

    private bool triggered = false;

    public void LoadNextScene()
    {
        if (triggered) return;

        triggered = true;

        StartCoroutine(LoadSceneAfterDelay());
    }

    private IEnumerator LoadSceneAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeLoading);
        SceneManager.LoadScene(nextSceneName);
    }


}
