using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleSkipDialogue : MonoBehaviour
{
    public void DialogueSkip()
    {
        GetComponent<MiddeDialogueManager>().skip = true;
        Debug.Log("Skipped");
    }
}
