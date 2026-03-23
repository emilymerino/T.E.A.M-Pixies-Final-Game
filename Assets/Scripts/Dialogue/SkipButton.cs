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

    public void classroomSkip()
    {
        GetComponent<ClassroomDialogue>().skipped = true;
        Debug.Log("Skipped");

    }

    public void afterTornNoteSkip()
    {
        GetComponent<AfterTornNoteDialogue>().skipped = true;
        Debug.Log("Skipped");

    }
}
