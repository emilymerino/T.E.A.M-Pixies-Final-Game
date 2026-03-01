using UnityEngine;

public class TestClue : MonoBehaviour
{
    public ClueData clue1;
    public ClueData clue2;

    public void GiveClue1() { ClueManager.Instance.UnlockClue(clue1); }
    public void GiveClue2() { ClueManager.Instance.UnlockClue(clue2); }
}