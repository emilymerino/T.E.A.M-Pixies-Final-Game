using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AfterTornNoteDialogue : MonoBehaviour
{
    public GameObject fadeTransition;
    [SerializeField] GameObject textBox;
    public GameObject mainText;
    public GameObject charName;

    public bool skipped = false;

    public GameObject eloise;

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
        yield return StartCoroutine(currentDialogue("Eloise", " I need to get back to the student council room quickly."));
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
