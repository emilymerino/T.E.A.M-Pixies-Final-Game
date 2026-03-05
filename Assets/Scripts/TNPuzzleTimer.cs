using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class TNPuzzleTimer : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private float startTimeSeconds = 15f;

    [Header("When time runs out")]
    [SerializeField] private GameObject gameOverText;
    [SerializeField] private GameObject puzzleRoot;
    [SerializeField] private TNPuzzlePieceDragSnap_UI[] puzzlePieces;


    private float timeLeft;
    private bool stopped;
    private bool timerStarted;


    // Start is called before the first frame update
    private void Start()
    {
        timeLeft = startTimeSeconds;
        timerStarted = false;

        if (gameOverText != null) gameOverText.SetActive(false);

        if (timerText != null)
            timerText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (!timerStarted || stopped) return;

        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0f)
        {
            timeLeft = 0f;
            UpdateTimerUI();
            TimeUp();
            return;
        }

        UpdateTimerUI();
    }

    public void StartTimer()
    {
        timerStarted = true;

        if (timerText != null)
            timerText.gameObject.SetActive(true);
    }

    private void UpdateTimerUI()
    {
        if (timerText == null) return;
        int display = Mathf.CeilToInt(timeLeft);
        timerText.text = "Time: " + display;
    }

    private void TimeUp()
    {
        stopped = true;

        foreach (var p in puzzlePieces)
            if (p != null) p.enabled = false;

        if (puzzleRoot != null) puzzleRoot.SetActive(false);

        if (timerText != null) timerText.gameObject.SetActive(false);

        if (gameOverText != null) gameOverText.SetActive(true);
    }

    public void StopTimer()
    {
        stopped = true;
        timerStarted = false;

        if (timerText != null) timerText.gameObject.SetActive(false);
    }
}
