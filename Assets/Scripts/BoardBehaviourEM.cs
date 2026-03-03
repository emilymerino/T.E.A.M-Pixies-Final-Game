using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardBehaviourEM : MonoBehaviour
{
    public List<GameObject> board; // list of squares to form minigame board
    public List<GameObject> shapes; // list of shapes

    void Start()
    {
        foreach (GameObject square in board)
        {
            square.SetActive(false);
        }

        foreach (GameObject shape in shapes)
        {
            shape.SetActive(false);
        }
    }

    public void ShowBoard()
    {
        foreach (GameObject square in board)
        {
            square.SetActive(true);
        }
    }

    public void ShowShapes()
    {
        foreach (GameObject shape in shapes)
        {
            shape.SetActive(true);
        }
    }

    public void HideBoard()
    {
        foreach (GameObject square in board)
        {
            square.SetActive(false);
        }
    }

    public void HideShapes()
    {
        foreach (GameObject shape in shapes)
        {
            shape.SetActive(false);
        }
    }
}
