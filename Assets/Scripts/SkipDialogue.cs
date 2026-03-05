using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipDialogue : MonoBehaviour
{
    public bool skip;

    public void DialogueSkip()
    {
        Debug.Log("Clicked");
        skip = true;
       Debug.Log("Skipped");
    }

}
