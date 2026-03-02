using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PlayerMemoryManagerMP : MonoBehaviour
{
    public PlayersPatternMP playersPatternMP;
    public SetPatternMP setPatternMP;
    public BoardBehaviourMP boardBehaviourMP;
    public PlayerLostPopUpMP playerLostPopUpMP;
    public PlayerWonPopUpMP playerWonPopUpMP;

    private List<GameObject> selectedSquares = new List<GameObject>(); // list of squares that have been selected
    public float timeRemaining = 5f;
    public bool timerIsRunning = false;
    public TextMeshProUGUI timerText;
    public bool canSelect = false;

    public void SelectedSquares(GameObject playersSquare)
    {
        if (!canSelect) return;

        if (!timerIsRunning) // timer has started
        {
            timeRemaining = 5f; // reset time
            timerIsRunning = true;
        }

        var spriteSquare = playersSquare.GetComponent<SpriteRenderer>();

        if (selectedSquares.Contains(playersSquare)) 
        {
            // deselect
            selectedSquares.Remove(playersSquare); 
            Debug.Log("Square removed: " + playersSquare.name);

            if (spriteSquare != null)
            {
                spriteSquare.enabled = false;
            }
        }
        else
        {
            // select
            selectedSquares.Add(playersSquare);
            Debug.Log("Square add: " + playersSquare.name);

            if (spriteSquare != null)
            {
                spriteSquare.enabled = true;
            }

            playersPatternMP.ShowSquares(playersSquare); // go to PlayerPattern script

        }
    }

    public void StartPlayerTurn()
    {
        canSelect = true;
        timeRemaining = 5f;
        timerIsRunning = false;
    }

    void Update()
    {
        if (timerText == null)
            timerText = GetComponent<TextMeshProUGUI>(); // grab timer text

        if (!timerIsRunning) return; // checks if timer has started

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime; // decrease time
            DisplayTime(timeRemaining); // show timer 
        }
        else // timer stoped
        {
            timeRemaining = 0;
            timerIsRunning = false;
            canSelect = false;

            bool result = ComparePatterns(setPatternMP.squaresToShow, selectedSquares);

            timerText.gameObject.SetActive(false);
            boardBehaviourMP.HideBorder(); // go to BorderBehaviour script

            ClearSelection();
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0) timeToDisplay = 0;

        TimeSpan timeSpan = TimeSpan.FromSeconds(timeToDisplay);
        timerText.text = string.Format("{0:00}:{1:00}", (int)timeSpan.TotalMinutes, timeSpan.Seconds);
    }

    public bool ComparePatterns(List<GameObject> squaresToShow, List<GameObject> selectedSquares)
    {
        if (squaresToShow.Count != selectedSquares.Count) // checks number of elements
        {
            playerLostPopUpMP.ShowLostPopUp();
            Debug.Log("Lists are not the same");
            return false;
        }

        foreach (GameObject square in squaresToShow)
        {
            if (!selectedSquares.Contains(square))
            {
                playerLostPopUpMP.ShowLostPopUp();
                Debug.Log("Lists are not the same");
                Debug.Log("Missing square: " + square.name);
                return false;
            }
        }
        playerWonPopUpMP.ShowWonPopUp();
        Debug.Log("Lists are the same");
        return true;
    }

    public void ClearSelection()
    {
        foreach (GameObject square in selectedSquares)
        {
            SpriteRenderer sprite = square.GetComponent<SpriteRenderer>();
            if (sprite != null)
            {
                sprite.enabled = false;
            }
        }
        selectedSquares.Clear();
        Debug.Log("Selection Cleared");
    }
}
