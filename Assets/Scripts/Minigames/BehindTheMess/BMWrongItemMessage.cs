using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BMWrongItemMessage : MonoBehaviour
{
    public TextMeshProUGUI messageText;
    public float showTime = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        if (messageText == null)
        {
            messageText = GetComponent<TextMeshProUGUI>();
        }

        messageText.enabled = false;
    }

    public void ShowMessage(string message)
    {
        StopAllCoroutines();
        StartCoroutine(ShowMessageRoutine(message));
    }

    private IEnumerator ShowMessageRoutine(string message)
    {
        messageText.text = message;
        messageText.enabled = true;

        yield return new WaitForSeconds(showTime);

        messageText.enabled = false;
    }
}
