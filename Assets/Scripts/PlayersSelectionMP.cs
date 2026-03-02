using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersSelectionMP : MonoBehaviour
{
    public PlayersPatternMP playerPatternMP;
    public BoardBehaviourMP boardBehaviourMP;
    public PlayerMemoryManagerMP playerMemoryManagerMP;

    public void EnablePlayerSelection()
    {
        boardBehaviourMP.ShowBorder(); // go to BorderBehaviour script
    }

    void OnMouseDown()
    {
        if (!CompareTag("Selectable")) return; // checks if game object is tagged "Selectable"
        //playerPattern.ShowPlayersPattern(); // go to PlayerPattern script
        playerMemoryManagerMP.SelectedSquares(gameObject); // adds square to list of squares selected in PlayerMemoryManager script
    }

}
