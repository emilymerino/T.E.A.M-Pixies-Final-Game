using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LCLockUnlockedBehaviour : MonoBehaviour
{
    public LCStatusLightsBehaviour statusLightsBehaviour;

    public SpriteRenderer LockUnlocked;

    public string nextSceneName;

    private void Start()
    {
        if (LockUnlocked == null)
        {
            LockUnlocked = GetComponent<SpriteRenderer>();
        }
        LockUnlocked.gameObject.SetActive(false); // starts hidden
    }
    public void ShowLockUnlocked()
    {
        LockUnlocked.gameObject.SetActive(true);
        statusLightsBehaviour.ShowUnlockedStatusLights();

        StartCoroutine(LoadNextSceneAfterDelay());
    }

    public void HideLockUnlocked()
    {
        LockUnlocked.gameObject.SetActive(false);
        enabled = false;
    }

    IEnumerator LoadNextSceneAfterDelay()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(nextSceneName);
    }
}
