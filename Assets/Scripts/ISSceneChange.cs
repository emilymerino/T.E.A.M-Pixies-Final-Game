using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ISSceneChange : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (CompareTag("SchoolDoors"))
        {
            SceneManager.LoadScene("FirstClassroomInteractionScene");
        }
        else if (CompareTag("OpenedBathroomDoor"))
        {
            SceneManager.LoadScene("InsideBathroomInteractionScene");
        }
        else if (CompareTag("TornNote"))
        {
            SceneManager.LoadScene("TornNoteScene");
        }
        else if (CompareTag("Locker"))
        {
            SceneManager.LoadScene("InfrontLockerInteractionScene");
        }
        else if (CompareTag("Lock"))
        {
            SceneManager.LoadScene("LockCodeScene");
        }
        else if (CompareTag("StorageRoomDoor"))
        {
            SceneManager.LoadScene("BehindTheMessScene");
        }
    }
}

