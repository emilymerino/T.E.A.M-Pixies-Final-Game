using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HallwayOfLockersDialogue : MonoBehaviour
{
    public GameObject fadeTransition;
    [SerializeField] GameObject textBox;
    public GameObject mainText;
    public GameObject charName;

    public bool skipped = false;

    public GameObject lockerGlow;
    public GameObject locker;
    public GameObject lockerModified;
    public GameObject exclamationMark;

    public float typingSpeed = 0.03f;


    // Start is called before the first frame update
    void Start()
    {
        fadeTransition.SetActive(true);
        mainText.SetActive(false);
        textBox.SetActive(false);

        lockerGlow.SetActive(false);
        locker.SetActive(false);
        lockerModified.SetActive(false);
        exclamationMark.SetActive(false);


        StartCoroutine(DialogueStart());
    }

    IEnumerator DialogueStart()
    {
        yield return new WaitForSeconds(2);
        fadeTransition.SetActive(false);
        yield return new WaitForSeconds(1);
        textBox.SetActive(true);
        mainText.SetActive(true);

        yield return StartCoroutine(currentDialogue("", "Eloise hurriedly makes her way back to the meeting room."));
        yield return StartCoroutine(currentDialogue("", "However, before she makes it back, something catches her eye."));

        textBox.SetActive(false);
        mainText.SetActive(false);

        lockerGlow.SetActive(true);
        locker.SetActive(true);
        lockerModified.SetActive(true);
        exclamationMark.SetActive(true);
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
