using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LCLockUnlockedBehaviour : MonoBehaviour
{
    public SpriteRenderer LockUnlocked;

    private void Start()
    {
        if (LockUnlocked == null)
        {
            LockUnlocked = GetComponent<SpriteRenderer>();
        }
        LockUnlocked.gameObject.SetActive(false); // starts hidden
    }
    public void ShowLockUnlocked()
    {
        LockUnlocked.gameObject.SetActive(true);
    }

    public void HideLockUnlocked()
    {
        LockUnlocked.gameObject.SetActive(false);
        enabled = false;
    }
}
