using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersSelection : MonoBehaviour
{
    public PlayerPattern playerPattern;
    public BorderBehaviour borderBehaviour;
    public PlayerMemoryManager playerMemoryManager;

    public void EnablePlayerSelection()
    {
        borderBehaviour.ShowBorder(); // go to BorderBehaviour script
    }

    void OnMouseDown()
    {
        if (!CompareTag("Selectable")) return; // checks if game object is tagged "Selectable"
        //playerPattern.ShowPlayersPattern(); // go to PlayerPattern script
        playerMemoryManager.SelectedSquares(gameObject); // adds square to list of squares selected in PlayerMemoryManager script
    }

}
