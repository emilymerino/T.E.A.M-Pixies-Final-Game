using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AfterBehindTheMessDialogue : MonoBehaviour
{
    public GameObject fadeTransition;
    [SerializeField] GameObject textBox;
    public GameObject mainText;
    public GameObject charName;

    public bool skipped = false;

    public bool dialogueFinished = false;
    public string nextSceneName = "21-OClassroom";

    void Start()
    {
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

        yield return StartCoroutine(currentDialogue("", "Eloise finds some unexpected things."));
        yield return StartCoroutine(currentDialogue("", "The first thing was the transfers where it shows a record of purchasing blood packets. It was probably what Mei was looking at in the meeting room earlier."));
        yield return StartCoroutine(currentDialogue("", "And the second thing was some sort of letter. Upon closer inspection, it seems to be… a love letter? It says it’s from Archie to Mei."));
        yield return StartCoroutine(currentDialogue("", "Though this was an odd love letter considering there’s an angry blurb at the end that talks about how upset Archie was to see Mei with Quinton last week."));
        yield return StartCoroutine(currentDialogue("", "It was an… interesting read."));
        yield return StartCoroutine(currentDialogue("", "Eloise pockets the stuff she has found. With new items, she's sure she’ll get more information from certain people."));
        yield return StartCoroutine(currentDialogue("", "She makes her way back to the meeting room. She’ll make sure to catch whoever did this to Mei."));
        dialogueFinished = true;
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
