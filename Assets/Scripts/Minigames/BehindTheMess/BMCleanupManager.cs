using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BMCleanupManager : MonoBehaviour
{
    public int cleanedItemCount = 0;
    public int totalItems = 0;

    public BMIndicatorPopUp indicatorPopUp;
    public BMLoveLetterClick loveLetterClick;

    private bool finished = false;

    public void AddCleanedItem()
    {
        if (finished) return;

        cleanedItemCount++;
        Debug.Log("Cleaned Items: " + cleanedItemCount);

        if (cleanedItemCount >= totalItems)
        {
            finished = true;
            Debug.Log("All items cleaned!");

            if (indicatorPopUp != null)
            {
                indicatorPopUp.ShowIndicator(indicatorPopUp.alertIndicator, 0f);
            }

            if (loveLetterClick != null)
            {
                loveLetterClick.RevealLetter();
            }
        }
    }

}
