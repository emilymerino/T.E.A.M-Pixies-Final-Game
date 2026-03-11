using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNAutoHideAfterSeconds : MonoBehaviour
{
    [SerializeField] private float seconds = 2f;
    [SerializeField] private GameObject nextObject;

    private void OnEnable()
    {
        StartCoroutine(Hide());
    }

    private IEnumerator Hide()
    {
        yield return new WaitForSeconds(seconds);

        gameObject.SetActive(false);

        if (nextObject != null)
            nextObject.SetActive(true);
    }
}
