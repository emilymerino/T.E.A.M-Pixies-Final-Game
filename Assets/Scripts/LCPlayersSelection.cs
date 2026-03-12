using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LCPlayersSelection : MonoBehaviour
{
    public LCPlayersPattern playerPattern;
    public LCBoardBehaviour boardBehaviour;
    public LCPlayerMemoryManager playerMemoryManager;

    public void EnablePlayerSelection()
    {
        boardBehaviour.ShowBorder(); // go to BorderBehaviour script
    }

    void OnMouseDown()
    {
        if (!CompareTag("Selectable")) return; // checks if game object is tagged "Selectable"
        //playerPattern.ShowPlayersPattern(); // go to PlayerPattern script
        playerMemoryManager.SelectedSquares(gameObject); // adds square to list of squares selected in PlayerMemoryManager script
    }

}
