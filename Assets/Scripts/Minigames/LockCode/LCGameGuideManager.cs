using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LCGameGuideManager : MonoBehaviour
{
    public TextMeshProUGUI WatchCombination;
    public TextMeshProUGUI InPlayInstructions;
    public TextMeshProUGUI YouGotIt;
    public string nextSceneName;

    [SerializeField] private TextMeshProUGUI NotQuite;

    void Start()
    {
        WatchCombination.gameObject.SetActive(false);
        InPlayInstructions.gameObject.SetActive(false);
        NotQuite.gameObject.SetActive(false);
        YouGotIt.gameObject.SetActive(false);
    }

    public void ShowWatchCombination()
    {
        WatchCombination.gameObject.SetActive(true);
    }

    public void HideWatchCombination()
    {
        WatchCombination.gameObject.SetActive(false);
    }

    public void ShowInPlayInstructions()
    {
        InPlayInstructions.gameObject.SetActive(true);
    }

    public void HideInPlayInstructions()
    {
        InPlayInstructions.gameObject.SetActive(false);
    }

    public void ShowNotQuite(string message, float duration)
    {
        StopAllCoroutines();
        StartCoroutine(ShowTextRoutine(message, duration));
    }

    private IEnumerator ShowTextRoutine(string message, float duration)
    {
        NotQuite.text = message;
        NotQuite.gameObject.SetActive(true);

        yield return new WaitForSeconds(duration); // wait for certain time

        NotQuite.gameObject.SetActive(false);
    }

    public void ShowYouGotIt()
    {
        YouGotIt.gameObject.SetActive(true);
        StartCoroutine(LoadNextSceneAfterDelay());
    }

    IEnumerator LoadNextSceneAfterDelay()
    {
        yield return new WaitForSeconds(3f); 
        SceneManager.LoadScene(nextSceneName);
    }

    public void HideYouGotIt()
    {
        YouGotIt.gameObject.SetActive(false);
    }
}
