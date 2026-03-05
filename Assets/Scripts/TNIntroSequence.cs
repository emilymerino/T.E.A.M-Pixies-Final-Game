using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNIntroSequence : MonoBehaviour
{
    [SerializeField] private float introDuration = 2f;
    [SerializeField] private GameObject instructionsTitle;
    [SerializeField] private GameObject instructionsBody;

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(Sequence());
    }

    private IEnumerator Sequence()
    {
        yield return new WaitForSeconds(introDuration);

        gameObject.SetActive(false);

        instructionsTitle.SetActive(true);
        instructionsBody.SetActive(true);
    }
}
