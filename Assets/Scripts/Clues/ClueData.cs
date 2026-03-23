using UnityEngine;

// allows clue creation from editor

[CreateAssetMenu(fileName = "New Clue", menuName = "Clue System/Clue")]
public class ClueData : ScriptableObject
{
// stores unique id, name, description and icon (in inventory)
    public string clueID;          
    public string clueName;      

    public string description;    
    public Sprite icon;           
}