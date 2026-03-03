using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNPuzzlePieceDragSnap : MonoBehaviour
{
    [Header("Snap Settings")]
    [SerializeField] private Transform snapTarget;
    [SerializeField] private float snapDistance = 0.6f;
    [SerializeField] private TNPuzzleCompletionManager completionManager;

    private Vector3 homePosition;
    private Vector3 offset;
    private bool isDragging;
    private bool isSnapped;


    // Start is called before the first frame update
    private void Start()
    {
        homePosition = transform.position;
    }

    private void OnMouseDown()
    {
        if (isSnapped) return;

        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorld.z = 0f;

        offset = transform.position - mouseWorld;
        isDragging = true;
    }

    private void OnMouseDrag()
    {
        if (!isDragging || isSnapped) return;

        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorld.z = 0f;

        transform.position = mouseWorld + offset;
    }

    private void OnMouseUp()
    {
        isDragging = false;

        if (snapTarget == null) return;

        float dist = Vector2.Distance(transform.position, snapTarget.position);

        if (dist <= snapDistance)
        {
            transform.position = snapTarget.position;
            isSnapped = true;

            if (completionManager != null) completionManager.RegisterPieceSnapped();
        }
        else
        {
            transform.position = homePosition;
        }
    }
}
