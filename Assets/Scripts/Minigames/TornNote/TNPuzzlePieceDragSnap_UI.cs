using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TNPuzzlePieceDragSnap_UI : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private RectTransform snapTarget;
    [SerializeField] private float snapDistance = 60f;
    [SerializeField] private TNPuzzleCompletionManager completionManager;

    private RectTransform rectTransform;
    private Canvas canvas;

    private Vector2 homeAnchoredPos;
    private Vector2 pointerOffset;
    private bool isSnapped;
    private bool reportedSnap;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        homeAnchoredPos = rectTransform.anchoredPosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isSnapped) return;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rectTransform, eventData.position, eventData.pressEventCamera, out var localPoint);

        pointerOffset = localPoint;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isSnapped) return;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isSnapped) return;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            (RectTransform)canvas.transform, eventData.position, eventData.pressEventCamera, out var canvasLocalPoint);

        rectTransform.anchoredPosition = canvasLocalPoint - pointerOffset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (isSnapped || snapTarget == null) return;

        float dist = Vector2.Distance(rectTransform.anchoredPosition, snapTarget.anchoredPosition);

        if (dist <= snapDistance)
        {
            rectTransform.anchoredPosition = snapTarget.anchoredPosition;
            isSnapped = true;

            if (!reportedSnap && completionManager != null)
            {
                reportedSnap = true;
                completionManager.RegisterPieceSnapped();
            }
        }
        else
        {
            rectTransform.anchoredPosition = homeAnchoredPos;
        }
    }
}