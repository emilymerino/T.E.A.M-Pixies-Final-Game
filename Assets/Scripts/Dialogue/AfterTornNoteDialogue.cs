using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AfterTornNoteDialogue : MonoBehaviour
{
    public GameObject fadeTransition;
    [SerializeField] GameObject textBox;
    public GameObject mainText;
    public GameObject charName;

    public bool skipped = false;

    public bool dialogueFinished = false;
    public string nextSceneName = "11-Lockers";

    public GameObject eloise;

    public float typingSpeed = 0.03f;

    // Start is called before the first frame update
    void Start()
    {
        eloise.SetActive(false);

        fadeTransition.SetActive(true);
        mainText.SetActive(false);
        textBox.SetActive(false);


        StartCoroutine(DialogueStart());
    }

    IEnumerator DialogueStart()
    {
        yield return new WaitForSeconds(2);
        fadeTransition.SetActive(false);
        yield return new WaitForSeconds(1);
        textBox.SetActive(true);
        mainText.SetActive(true);

        yield return StartCoroutine(currentDialogue("", "The note reveals an eerie message."));
        yield return StartCoroutine(currentDialogue("", "“Mei, meet me in the storage room before the council meeting.I need to talk to you about something important. Please don’t tell anyone about this. I’ll be waiting. - Q”"));
        eloise.SetActive(true);
        yield return StartCoroutine(currentDialogue("Eloise", "Q...?"));
        yield return StartCoroutine(currentDialogue("Eloise", " I only know one person who's name starts with a Q... I'll have to talk to him about this when I see him."));
        dialogueFinished = true;
        yield return StartCoroutine(currentDialogue("Eloise", " I need to get back to the student council room quickly."));
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
