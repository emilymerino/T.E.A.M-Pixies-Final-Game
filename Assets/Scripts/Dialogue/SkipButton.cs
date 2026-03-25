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

    public void afterLockCodeSkip()
    {
        AfterLockCodeDialogue dialogue = GetComponent<AfterLockCodeDialogue>();

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

    public void firstConversationsSkip()
    {
        FirstConversationsDialogue dialogue = GetComponent<FirstConversationsDialogue>();

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

    public void insideStorageRoomSkip()
    {
        InsideStorageRoomDialogue dialogue = GetComponent<InsideStorageRoomDialogue>();

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

    public void afterBehindTheMessSkip()
    {
        AfterBehindTheMessDialogue dialogue = GetComponent<AfterBehindTheMessDialogue>();

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

    public void secondConversationsSkip()
    {
        SecondConversationsDialogue dialogue = GetComponent<SecondConversationsDialogue>();

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

    public void rightGuessEndingSkip()
    {
        RightGuessEndingDialogue dialogue = GetComponent<RightGuessEndingDialogue>();

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

    public void wrongGuessEndingSkip()
    {
        WrongGuessEndingDialogue dialogue = GetComponent<WrongGuessEndingDialogue>();

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

    public void secondBathroomSkip()
    {
        SecondConversationsDialogue dialogue = GetComponent<SecondConversationsDialogue>();

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
}
