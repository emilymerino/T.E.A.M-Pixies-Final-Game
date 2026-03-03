using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNPuzzleCompletionManager : MonoBehaviour
{
    [Header("Win Condition")]
    [SerializeField] private int totalPieces = 6;
    private int snappedCount = 0;
    private bool successTriggered = false;

    [Header("References")]
    [SerializeField] private TNPuzzleTimer timer;
    [SerializeField] private GameObject puzzleRoot;
    [SerializeField] private GameObject noteOverlayRoot;

    public void RegisterPieceSnapped()
    {
        if (successTriggered) return;

        snappedCount++;

        if (snappedCount >= totalPieces)
        {
            successTriggered = true;
            StartCoroutine(SuccessSequence());
        }
    }

    private IEnumerator SuccessSequence()
    {
        if (timer != null) timer.StopTimer();

        if (puzzleRoot != null) puzzleRoot.SetActive(false);

        if (noteOverlayRoot != null) noteOverlayRoot.SetActive(true);

        yield break;
    }
}
