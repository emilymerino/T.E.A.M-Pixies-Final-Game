using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipDialogue : MonoBehaviour
{
    public void DialogueSkip()
    {
       GetComponent<DDialogueManager>().skip = true;
       Debug.Log("Skipped");
    }

}
