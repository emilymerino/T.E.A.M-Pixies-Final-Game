using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class MatchCheckerEM : MonoBehaviour
{
    public PlayersSelectionEM playersSelectionEM;
    public GameOverPopUpEM gameOverPopUpEM;
    public BoardBehaviourEM boardBehaviourEM;
    public PlayerLostPopUpEM playerLostPopUpEM;
    public PlayerWonPopUpEM playerWonPopUpEM;

    public PlayersSelectionEM firstSelected;
    public PlayersSelectionEM secondSelected;

    public TextMeshProUGUI timerText;

    private float resetTimer = 0f;
    public float timeRemaining = 5f;

    private bool waitingReset = false;
    public bool timerIsRunning = false;

    public void SelectShape(GameObject obj)
    {
        PlayersSelectionEM shape = obj.GetComponent<PlayersSelectionEM>();

        if (firstSelected == null)
        {
            firstSelected = shape;
        }
        else if (secondSelected == null && shape != firstSelected)
        {
            secondSelected = shape;
            CheckMatch();
        }

        if (!timerIsRunning) // timer has started
        {
            timeRemaining = 5f; // reset time
            timerIsRunning = true;
        }
    }

    public void DeselectShape(GameObject obj)
    {
        PlayersSelectionEM shape = obj.GetComponent<PlayersSelectionEM>();

        if (shape == firstSelected)
        {
            firstSelected = null;
        }
        else if (shape == secondSelected)
        {
            secondSelected = null;
        }
    }

    public void Update()
    {
        if (timerText == null)
        {
            timerText = GetComponent<TextMeshProUGUI>(); // grab timer text
        }

        if (!timerIsRunning) return; // checks if timer has started

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime; // decrease time
            DisplayTime(timeRemaining); // show timer 
        }
        else // timer stopped
        {
            timeRemaining = 0;
            timerIsRunning = false;

            timerText.gameObject.SetActive(false);

            foreach (PlayersSelectionEM shape in FindObjectsOfType<PlayersSelectionEM>())
            {
                shape.RemoveShape();
            }
            playerLostPopUpEM.ShowLostPopUp();
            boardBehaviourEM.HideBoard();
        }
        if (waitingReset)
        {
            resetTimer += Time.deltaTime;

            if (resetTimer >= 1f)
            {
                ResetSelections();
                resetTimer = 0f;
                waitingReset = false;
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0) timeToDisplay = 0;

        TimeSpan timeSpan = TimeSpan.FromSeconds(timeToDisplay);
        timerText.text = string.Format("{0:00}:{1:00}", (int)timeSpan.TotalMinutes, timeSpan.Seconds);
    }

    public void CheckMatch()
    {
        if (firstSelected != null && secondSelected != null)
        {
            if (firstSelected.shape == secondSelected.shape)
            {
                Debug.Log("You Got A Match !");

                if (FindObjectsOfType<PlayersSelectionEM>().Length == 2)
                {
                    timerIsRunning = false;
                    timeRemaining = 0f;
                    DisplayTime(timeRemaining);
                    timerText.gameObject.SetActive(false);

                    firstSelected.RemoveShape();
                    secondSelected.RemoveShape();

                    boardBehaviourEM.HideBoard();
                    playerWonPopUpEM.ShowWonPopUp();
                }
                else
                {
                    firstSelected.RemoveShape();
                    secondSelected.RemoveShape();
                }
                ResetSelections();
            }
            else
            {
                Debug.Log("No Match, Try Again");

                // prevents player selecting while waiting
                firstSelected.canSelect = false;
                secondSelected.canSelect = false;

                resetTimer = 0f;
                waitingReset = true;
            }
        }
    }


    public void ResetSelections()
    {
        if (firstSelected != null)
            firstSelected.ForceDeselect();

        if (secondSelected != null)
            secondSelected.ForceDeselect();

        firstSelected = null;
        secondSelected = null;
    }
}
