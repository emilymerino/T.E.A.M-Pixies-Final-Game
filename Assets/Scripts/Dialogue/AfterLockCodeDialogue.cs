using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AfterLockCodeDialogue : MonoBehaviour
{
    public GameObject fadeInTransition;
    [SerializeField] GameObject textBox;
    public GameObject mainText;
    public GameObject charName;

    public bool skipped = false;

    public bool dialogueFinished = false;
    public string nextSceneName = "15-OClassroom";

    public float typingSpeed = 0.03f;

    public ClueData clue3; // locker findings note popup


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
        ClueManager.Instance.UnlockClue(clue3); // unlocked third clue

        yield return StartCoroutine(currentDialogue("", "She looks through the pockets and finds a crumpled sticky note."));
        yield return StartCoroutine(currentDialogue("", "“Meeting you about the missing transfers. This ends tonight.”"));
        yield return StartCoroutine(currentDialogue("", "She also finds a blood stained medical vial in the locker, possibly the vampire hiding their tracks. Mei confronted the vampire and died in the process."));
        dialogueFinished = true;
        yield return StartCoroutine(currentDialogue("", "Eloise pockets her findings and closes the locker door. She needs to know what exactly happened."));

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

        if (dialogueFinished)
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
