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
            SceneManager.LoadScene("FirstOutsideStudentCouncilInteractionScene");
        }
        else if (CompareTag("FirstStudentCouncilDoor"))
        {
            SceneManager.LoadScene("EnterStudentCouncilInteractionScene");
        }
        else if (CompareTag("FirstOpenedBathroomDoor"))
        {
            SceneManager.LoadScene("FirstInsideBathroomInteractionScene");
        }
        else if (CompareTag("TornNote"))
        {
            SceneManager.LoadScene("TornNoteScene");
        }
        else if (CompareTag("Locker"))
        {
            SceneManager.LoadScene("InfrontOfLockerInteractionScene");
        }
        else if (CompareTag("Lock"))
        {
            SceneManager.LoadScene("LockCodeScene");
        }
        else if (CompareTag("StorageRoomDoor"))
        {
            SceneManager.LoadScene("BehindTheMessScene");
        }
        else if (CompareTag("SecondStudentCouncilDoor"))
        {
            SceneManager.LoadScene("FirstConversationsInteractionScene");
        }
        else if (CompareTag("StorageRoomDoor"))
        {
            SceneManager.LoadScene("BehindTheMessScene");
        }
        else if (CompareTag("StorageRoomDoor"))
        {
            SceneManager.LoadScene("BehindTheMessScene");
        }
        else if (CompareTag("ThirdStudentCouncilDoor"))
        {
            SceneManager.LoadScene("SecondConversationsInteractionScene");
        }
        else if (CompareTag("SecondOpenedBathroomDoor"))
        {
            SceneManager.LoadScene("SecondInsideBathroomInteractionScene");
        }
    }
}

