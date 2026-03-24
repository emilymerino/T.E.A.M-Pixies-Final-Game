using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipButton : MonoBehaviour
{
    public void outsideSkip()
    {
        OutsideDialogue dialogue = GetComponent<OutsideDialogue>();

        if (dialogue.dialogueFinished)
        {
            SceneManager.LoadScene(dialogue.nextSceneName);
        }
        else
        {
            dialogue.skipped = true;
            Debug.Log("Skipped");
        }
    }

    public void firstBathroomSkip()
    {
        FirstBathroomDialogue dialogue = GetComponent<FirstBathroomDialogue>();

        if (dialogue.dialogueFinished)
        {
            SceneManager.LoadScene(dialogue.nextSceneName);
        }
        else
        {
            dialogue.skipped = true;
            Debug.Log("Skipped");
        }
    }

    public void classroomSkip()
    {
        ClassroomDialogue dialogue = GetComponent<ClassroomDialogue>();

        if (dialogue.dialogueFinished)
        {
            SceneManager.LoadScene(dialogue.nextSceneName);
        }
        else
        {
            dialogue.skipped = true;
            Debug.Log("Skipped");
        }
    }

    public void afterTornNoteSkip()
    {
        AfterTornNoteDialogue dialogue = GetComponent<AfterTornNoteDialogue>();

        if (dialogue.dialogueFinished)
        {
            SceneManager.LoadScene(dialogue.nextSceneName);
        }
        else
        {
            dialogue.skipped = true;
            Debug.Log("Skipped");
        }

    }

    public void hallwayOfLockersSkip()
    {
        GetComponent<HallwayOfLockersDialogue>().skipped = true;
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
}
