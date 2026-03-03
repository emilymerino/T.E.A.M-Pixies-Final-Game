using UnityEngine;

public class TestClueGiver : MonoBehaviour
{
    public ClueData clue1;
    public ClueData clue2;
    public ClueData clue3;
    public ClueData clue4;
    public ClueData clue5;
    public ClueData clue6;
    public ClueData clue7;
    public ClueData clue8;
    public ClueData clue9;
    public ClueData clue10;
    public ClueData clue11;

    public void GiveAllClues()
    {
        UnlockIfExists(clue1);
        UnlockIfExists(clue2);
        UnlockIfExists(clue3);
        UnlockIfExists(clue4);
        UnlockIfExists(clue5);
        UnlockIfExists(clue6);
        UnlockIfExists(clue7);
        UnlockIfExists(clue8);
        UnlockIfExists(clue9);
        UnlockIfExists(clue10);
        UnlockIfExists(clue11);
    }

    void UnlockIfExists(ClueData clue)
    {
        if (clue != null)
            ClueManager.Instance.UnlockClue(clue);
    }
}