using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OBDoorsBehaviour : MonoBehaviour
{
    public SpriteRenderer OpenedDoor;
    public SpriteRenderer ClosedDoor;

    private void Start()
    {
        {
            OpenedDoor.gameObject.SetActive(false); // starts hidden
        }
    }

    private void OnMouseDown()
    {
        OpenedDoor.gameObject.SetActive(true);
        HideClosedBathroomDoor();
    }

    public void HideClosedBathroomDoor()
    {
        ClosedDoor.gameObject.SetActive(false);
    }
}

