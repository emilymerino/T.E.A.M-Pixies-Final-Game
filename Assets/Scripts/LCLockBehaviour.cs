using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LCLockBehaviour : MonoBehaviour
{
    public LCInstructionsPopUp instructionsPopUp;
    public LCCombination combination;
    public LCGameGuideManager gameGuideManager;

    public SpriteRenderer Lock;

    void Start()
    {
        if (Lock == null)
        {
            Lock = GetComponent<SpriteRenderer>();
        }
        Lock.gameObject.SetActive(false); // starts hidden
    }

    public void ShowLock()
    {
        Lock.gameObject.SetActive(true);
        StartCoroutine(combination.DelayAction(2.0f));
        gameGuideManager.HideYouGotIt();
    }

    public void HideLock()
    {
        Lock.gameObject.SetActive(false);
        enabled = false;
    }
}
