using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPattern : MonoBehaviour
{
    public List<GameObject> playersSquaresToShow; // list of squares that players selected

    public float displayDuration = 1f;
    private float timer;
    private int currentIndex = 0;

    void Start()
    {
        foreach (GameObject square in playersSquaresToShow)
        {
            var spriteSquare = square.GetComponent<SpriteRenderer>();
            if (spriteSquare != null)
            {
                spriteSquare.enabled = false;
            }
        }
        enabled = false;
    }

    public void ShowPlayersPattern()
    {
        currentIndex = 0;
        timer = 0f;
        enabled = true;
    }

    public void ShowSquares(GameObject playersSquare) // shows players selected squares
    {
        if (!playersSquaresToShow.Contains(playersSquare))
        {
            playersSquaresToShow.Add(playersSquare);
        }

        var spriteSquare = playersSquare.GetComponent<SpriteRenderer>();
        if (spriteSquare != null)
        {
            spriteSquare.enabled = true;
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= displayDuration)
        {
            if (currentIndex < playersSquaresToShow.Count) // show next square
            {
                var spriteSquare = playersSquaresToShow[currentIndex].GetComponent<SpriteRenderer>();
                if (spriteSquare != null)
                {
                    spriteSquare.enabled = true;
                }
                currentIndex++;
            }
            timer = 0;
        }
    }
}
