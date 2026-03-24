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
            SceneManager.LoadScene("4-OClassroom");
        }
        else if (CompareTag("FirstStudentCouncilDoor"))
        {
            SceneManager.LoadScene("5-Classroom");
        }
        else if (CompareTag("FirstOpenedBathroomDoor"))
        {
            SceneManager.LoadScene("7-FirstBathroom");
        }
        else if (CompareTag("TornNote"))
        {
            SceneManager.LoadScene("9-TornNote");
        }
        else if (CompareTag("Locker"))
        {
            SceneManager.LoadScene("12-InfrontOfLockers");
        }
        else if (CompareTag("Lock"))
        {
            SceneManager.LoadScene("13-LockCode");
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

