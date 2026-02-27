using UnityEngine;

public class TestClue : MonoBehaviour
{
    public ClueData testClue;

    public void GiveClue()
    {
        ClueManager.Instance.UnlockClue(testClue);
    }
}