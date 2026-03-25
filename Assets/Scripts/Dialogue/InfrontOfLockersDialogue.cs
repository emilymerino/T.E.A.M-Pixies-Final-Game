using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfrontOfLockersDialogue : MonoBehaviour
{
    [SerializeField] GameObject textBox;
    public GameObject mainText;
    public GameObject charName;

    public GameObject lockOnLocker;
    public GameObject lockOnLockerImage;
    public GameObject lockGlow;
    public GameObject exclamationMark;

    public bool skipped = false;

    // Start is called before the first frame update
    void Start()
    {
        lockOnLocker.SetActive(false);
        lockOnLockerImage.SetActive(true);
        lockGlow.SetActive(false);
        exclamationMark.SetActive(false);

        StartCoroutine(DialogueStart());
    }

    IEnumerator DialogueStart()
    {
        yield return StartCoroutine(currentDialogue("", "Eloise stumbles upon a locker with a bloodstained sleeve hanging out of it."));
        yield return StartCoroutine(currentDialogue("", "This is not coincedence, this has to be related to Mei's murder in some way."));
        yield return StartCoroutine(currentDialogue("", "There has to be a way to unlock this door."));

        lockOnLocker.SetActive(true);
        lockOnLockerImage.SetActive(false);
        lockGlow.SetActive(true);
        exclamationMark.SetActive(true);

        textBox.SetActive(false);
        mainText.SetActive(false);
        charName.SetActive(false);
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

    }
}
