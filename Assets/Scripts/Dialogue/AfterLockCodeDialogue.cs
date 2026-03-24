using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AfterLockCodeDialogue : MonoBehaviour
{
    public GameObject fadeInTransition;
    [SerializeField] GameObject textBox;
    public GameObject mainText;
    public GameObject charName;

    public bool skipped = false;


    // Start is called before the first frame update
    void Start()
    {
        fadeInTransition.SetActive(true);
        mainText.SetActive(false);
        textBox.SetActive(false);

        StartCoroutine(DialogueStart());
    }

    IEnumerator DialogueStart()
    {
        yield return new WaitForSeconds(2);
        fadeInTransition.SetActive(false);
        yield return new WaitForSeconds(1);
        textBox.SetActive(true);
        mainText.SetActive(true);

        yield return StartCoroutine(currentDialogue("", "Eloise opens the locker door and inside was a blood-stained council blazer."));
        yield return StartCoroutine(currentDialogue("", "She looks through the pockets and finds a crumpled sticky note."));
        yield return StartCoroutine(currentDialogue("", "“Meeting you about the missing transfers. This ends tonight.”"));
        yield return StartCoroutine(currentDialogue("", "She also finds a blood stained medical vial in the locker, possibly the vampire hiding their tracks. Mei confronted the vampire and died in the process."));
        yield return StartCoroutine(currentDialogue("", "Eloise pockets her findings and closes the locker door. She needs to know what exactly happened."));

    }

    IEnumerator currentDialogue(string name, string dialogue)
    {
        mainText.GetComponent<TMP_Text>().text = dialogue;
        charName.GetComponent<TMP_Text>().text = name;

        while (skipped == false)
        {
            yield return new WaitForSeconds(0.1f);
        }

        skipped = false;
        Debug.Log("Skipped dialogue");
        yield break;

    }
}
