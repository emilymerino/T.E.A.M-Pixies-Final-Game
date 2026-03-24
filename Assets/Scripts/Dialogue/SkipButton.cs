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

    public void firstConversationsSkip()
    {
        GetComponent<FirstConversationsDialogue>().skipped = true;
        Debug.Log("Skipped");

    }

    public void firstSelectionSkip()
    {
        GetComponent<FCSelection>().skipped = true;
        Debug.Log("Skipped");

    }
}
