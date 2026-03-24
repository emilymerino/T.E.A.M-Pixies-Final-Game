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

    public void hallwayOfLockersSkip()
    {
        GetComponent<HallwayOfLockersDialogue>().skipped = true;
        Debug.Log("Skipped");

    }

    public void afterLockCodeSkip()
    {
        GetComponent<AfterLockCodeDialogue>().skipped = true;
        Debug.Log("Skipped");

    }

    public void firstConversationsSkip()
    {
        GetComponent<FirstConversationsDialogue>().skipped = true;
        Debug.Log("Skipped");

    }

    public void afterBehindTheMessSkip()
    {
        GetComponent<AfterBehindTheMessDialogue>().skipped = true;
        Debug.Log("Skipped");
    }

    public void rightGuessEndingSkip()
    {
        GetComponent<RightGuessEndingDialogue>().skipped = true;
        Debug.Log("Skipped");
    }

    public void wrongGuessEndingSkip()
    {
        GetComponent<WrongGuessEndingDialogue>().skipped = true;
        Debug.Log("Skipped");
    }

    public void secondBathroomSkip()
    {
        GetComponent<SecondBathroomDialogue>().skipped = true;
        Debug.Log("Skipped");
    }
}
