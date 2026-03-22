using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipButton : MonoBehaviour
{

    public void skipDialogue()
    {
        GetComponent<OutsideDialogue>().skipped = true;
        Debug.Log("Skipped");

    }
}
