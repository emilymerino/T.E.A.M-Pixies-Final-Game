using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SetPatternMP : MonoBehaviour
{
    public PlayersPatternMP playersPatternMP;
    public PlayerMemoryManagerMP playerMemoryManagerMP;

    public SetPatternMP setPatternMP;
    public BoardBehaviourMP boardBehaviourMP;
    public ReadyPopUpMP readyPopUpMP;
    public List<GameObject> squaresToShow; // list of squares to form pattern
    public float displayDuration = 1f;
    private float timer;
    private int currentIndex = 0;
    private int repeatCount = 0;
    private int maxRepeats = 2;

    void Start()
    {
        foreach (GameObject square in squaresToShow)
        {
            var spriteSquare = square.GetComponent<SpriteRenderer>();
            if (spriteSquare != null)
            {
                spriteSquare.enabled = false;
            }
        }
        enabled = false;
    }

    public void ShowPattern()
    {
        currentIndex = 0;
        repeatCount = 0;
        timer = 0f;
        enabled = true;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= displayDuration)
        {
            if (currentIndex > 0) // hide previous square
            {
                var prevSpriteSquare = squaresToShow[currentIndex - 1].GetComponent<SpriteRenderer>();
                if (prevSpriteSquare != null)
                {
                    prevSpriteSquare.enabled = false;
                }
            }

            if (currentIndex < squaresToShow.Count) // show next square
            {
                var spriteSquare = squaresToShow[currentIndex].GetComponent<SpriteRenderer>();
                if (spriteSquare != null)
                {
                    spriteSquare.enabled = true;
                }
                currentIndex++;
            }

            else
            {
                repeatCount++;
                if (repeatCount < maxRepeats)
                {
                    currentIndex = 0; // restart pattern
                }
                else // hide last square
                {
                    var lastSpriteSquare = squaresToShow[squaresToShow.Count - 1].GetComponent<SpriteRenderer>();
                    if (lastSpriteSquare != null)
                    {
                        lastSpriteSquare.enabled = false;
                    }
                    boardBehaviourMP.HideBorder(); // go to BorderBehaviour script
                    readyPopUpMP.ShowText();

                    playerMemoryManagerMP.StartPlayerTurn();

                    enabled = false;
                }
            }
            timer = 0;
        }
    }
}
