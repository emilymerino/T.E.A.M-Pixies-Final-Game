using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchCheckerEM : MonoBehaviour
{
    public PlayersSelectionEM playersSelectionEM;

    public PlayersSelectionEM firstSelected;
    public PlayersSelectionEM secondSelected;

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
        if (!timerIsRunning) return; // checks if timer has started

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime; // decrease time
        }
        else // timer stopped
        {
            timeRemaining = 0;
            timerIsRunning = false;

            foreach (PlayersSelectionEM shape in FindObjectsOfType<PlayersSelectionEM>())
            {
                shape.RemoveShape();
            }
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

    public void CheckMatch()
    {
        if (firstSelected != null && secondSelected != null)
        {
            if (firstSelected.shape == secondSelected.shape)
            {
                Debug.Log("You Got A Match !");

                firstSelected.RemoveShape();
                secondSelected.RemoveShape();

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
