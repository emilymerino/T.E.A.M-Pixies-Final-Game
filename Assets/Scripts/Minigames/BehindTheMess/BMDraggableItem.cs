using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BMDraggableItem : MonoBehaviour
{
    private Vector3 offset;
    private Vector3 originalPosition;
    private Camera mainCamera;
    private bool isOverBox = false;
    private bool hasBeenCollected = false;

    public GameObject matchingCross;
    public BMCleanupManager cleanupManager;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        originalPosition = transform.position;
    }

    void OnMouseDown()
    {
        if (hasBeenCollected) return;

        Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f;
        offset = transform.position - mouseWorldPos;
    }

    void OnMouseDrag()
    {
        if (hasBeenCollected) return;

        Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f;
        transform.position = mouseWorldPos + offset;
    }

    void OnMouseUp()
    {
        if (hasBeenCollected) return;

        if (isOverBox)
        {
            hasBeenCollected = true;

            if (matchingCross != null)
            {
                matchingCross.SetActive(true);
            }

            if (cleanupManager != null)
            {
                cleanupManager.AddCleanedItem();
            }

            gameObject.SetActive(false);
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
