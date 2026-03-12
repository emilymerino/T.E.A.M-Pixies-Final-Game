using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingSkipDialogue : MonoBehaviour
{
    public void DialogueSkip()
    {
        GetComponent<EndingDialogueManager>().skip = true;
        Debug.Log("Skipped");
    }
}
