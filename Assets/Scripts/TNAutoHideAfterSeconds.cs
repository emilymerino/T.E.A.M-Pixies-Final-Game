using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNAutoHideAfterSeconds : MonoBehaviour
{
    [SerializeField] private GameObject nextObject;

    public void HideObject()
    {
        gameObject.SetActive(false);

        if (nextObject != null)
            nextObject.SetActive(true);
    }
}
