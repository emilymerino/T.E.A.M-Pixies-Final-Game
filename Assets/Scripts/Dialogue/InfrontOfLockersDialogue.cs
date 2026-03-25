using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public float typingSpeed = 0.03f;

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
        TMP_Text mainTMP = mainText.GetComponent<TMP_Text>();
        TMP_Text nameTMP = charName.GetComponent<TMP_Text>();

        nameTMP.text = name;
        mainTMP.text = "";

        skipped = false;

        for (int i = 0; i < dialogue.Length; i++)
        {
            if (skipped)
            {
                mainTMP.text = dialogue;
                break;
            }

            mainTMP.text += dialogue[i];
            yield return new WaitForSeconds(typingSpeed);
        }

        skipped = false;

        while (!skipped)
        {
            yield return null;
        }

        skipped = false;
        Debug.Log("Skipped dialogue");
    }
}
