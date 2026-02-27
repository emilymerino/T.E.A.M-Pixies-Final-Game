using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersSelectionEM : MonoBehaviour
{
    public BoardBehaviourEM boardBehaviourEM;

    public void SelectShape()
    {
        boardBehaviourEM.ShowBoard(); // go to BoardBehaviour script
    }

    public void DeselectShape()
    {

    }

    void OnMouseDown()
    {
        if (!CompareTag("Selectable")) return;

        Debug.Log("Selectable object clicked !");
    }
}
