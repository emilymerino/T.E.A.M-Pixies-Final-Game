using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BMWrongDraggableItem : MonoBehaviour
{
    private Vector3 offset;
    private Vector3 originalPosition;
    private Camera mainCamera;
    private bool isOverBox = false;

    public BMWrongItemMessage wrongItemMessage;
    public string wrongMessage = "That doesn't belong in the box.";

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        originalPosition = transform.position;
    }

    void OnMouseDown()
    {
        Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f;
        offset = transform.position - mouseWorldPos;
    }

    void OnMouseDrag()
    {
        Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f;
        transform.position = mouseWorldPos + offset;
    }

    void OnMouseUp()
    {
        if (isOverBox)
        {
            transform.position = originalPosition;

            if (wrongItemMessage != null)
            {
                wrongItemMessage.ShowMessage(wrongMessage);
            }
        }
        else
        {
            transform.position = originalPosition;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DropBox"))
        {
            isOverBox = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("DropBox"))
        {
            isOverBox = false;
        }
    }
}
