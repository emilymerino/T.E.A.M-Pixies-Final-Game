using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ClassroomDialogue : MonoBehaviour
{
    public GameObject fadeTransition;
    [SerializeField] GameObject textBox;
    public GameObject mainText;
    public GameObject charName;

    public bool skipped = false;

    public bool dialogueFinished = false;
    public string nextSceneName = "6-OBathroom";

    public GameObject eloise;
    public GameObject meiStern;
    public GameObject meiHappy;

    // Start is called before the first frame update
    void Start()
    {
        eloise.SetActive(false);
        meiStern.SetActive(false);
        meiHappy.SetActive(false);

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

        yield return StartCoroutine(currentDialogue("", "They reach the empty meeting room and the two girls take a seat."));
        yield return StartCoroutine(currentDialogue("", "Mei glances at her agenda and mumbles something to herself."));
        meiStern.SetActive(true);
        yield return StartCoroutine(currentDialogue("Mei", "I can’t believe someone messed with the club’s budget… I have to ask them about this before the meeting starts."));
        meiStern.SetActive(false);
        eloise.SetActive(true);
        yield return StartCoroutine(currentDialogue("Eloise", "What's wrong?"));
        meiHappy.SetActive(true);
        eloise.SetActive(false);
        yield return StartCoroutine(currentDialogue("Mei", "Oh, it’s nothing! Don’t worry about it."));
        meiHappy.SetActive(false);
        yield return StartCoroutine(currentDialogue("", "..."));
        meiHappy.SetActive(true);
        yield return StartCoroutine(currentDialogue("Mei", "Hey, I’ll be right back, just going to go to the washroom."));
        meiHappy.SetActive(false);
        eloise.SetActive(true);
        yield return StartCoroutine(currentDialogue("Eloise", "Alright..."));
        eloise.SetActive(false);
        yield return StartCoroutine(currentDialogue("", "Mei stands up, agenda in hand, and heads out the room."));
        yield return StartCoroutine(currentDialogue("", "Rain began tapping softly against the glass, then quickly turned into a relentless downpour. Eloise closes her eyes for a moment."));
        yield return StartCoroutine(currentDialogue("", "The quiet was then shattered by a blood-curdling scream. It came from the bathroom."));
        yield return StartCoroutine(currentDialogue("", "Hurried footsteps fled in the opposite direction, someone was running away."));
        dialogueFinished = true;
        yield return StartCoroutine(currentDialogue("", "Eloise’s stomach dropped. She rushes into the dim hallway."));
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
        if (dialogueFinished)
        {
            SceneManager.LoadScene(nextSceneName);
        }

        yield break;

    }
}