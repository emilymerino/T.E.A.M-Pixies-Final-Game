using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipButton : MonoBehaviour
{

    public void outsideSkip()
    {
        GetComponent<OutsideDialogue>().skipped = true;
        Debug.Log("Skipped");

    }

    public void firstBathroomSkip()
    {
        GetComponent<FirstBathroomDialogue>().skipped = true;
        Debug.Log("Skipped");

    }
}
