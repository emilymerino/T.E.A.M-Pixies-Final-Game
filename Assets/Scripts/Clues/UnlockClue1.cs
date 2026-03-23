using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockClue1 : MonoBehaviour
{
    public Button myButton;
    public ClueData clue1;

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
        }
    }
    
}
