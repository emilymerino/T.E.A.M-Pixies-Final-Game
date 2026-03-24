using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockClue1 : MonoBehaviour
{
    public Button myButton;
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
    public ClueData clue12;
    public ClueData clue13;
    public ClueData clue14;
   

    void Start()
    {
        if (myButton != null) 
        {
            myButton.onClick.AddListener(OnClickUnlockClue);
        }
 
    }

    void OnClickUnlockClue()
    {
        if (ClueManager.Instance != null && clue1 != null)
        {
            ClueManager.Instance.UnlockClue(clue1);
            ClueManager.Instance.UnlockClue(clue2);
            ClueManager.Instance.UnlockClue(clue3);
            ClueManager.Instance.UnlockClue(clue4);
            ClueManager.Instance.UnlockClue(clue5);
            ClueManager.Instance.UnlockClue(clue6);
            ClueManager.Instance.UnlockClue(clue7);
            ClueManager.Instance.UnlockClue(clue8);
            ClueManager.Instance.UnlockClue(clue9);
            ClueManager.Instance.UnlockClue(clue10);
            ClueManager.Instance.UnlockClue(clue11);
            ClueManager.Instance.UnlockClue(clue12);
            ClueManager.Instance.UnlockClue(clue13);
            ClueManager.Instance.UnlockClue(clue14);

        }
    }
    
}
