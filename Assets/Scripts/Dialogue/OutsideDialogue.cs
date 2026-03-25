using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class OutsideDialogue : MonoBehaviour
{
    public GameObject fadeTransition;
    [SerializeField] GameObject textBox;
    public GameObject mainText;
    public GameObject charName;

    public bool skipped = false;

    public bool dialogueFinished = false;
    public string nextSceneName = "3-Outside";

    public GameObject mei;
    public GameObject eloise;

    public float typingSpeed = 0.03f;

    // Start is called before the first frame update
    void Start()
    {
        mei.SetActive(false);
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

        yield return StartCoroutine(currentDialogue("", "Mei and Eloise walked to the afterschool student council meeting beneath a sky heavy with storm clouds."));
        yield return StartCoroutine(currentDialogue("", "They were exhausted after a long, dreary day, joking about how they’d both collapse into bed the second the meeting ended."));
        mei.SetActive(true);
        yield return StartCoroutine(currentDialogue("Mei", "This is probably the worst day to have a meeting. All I want to do is curl up in bed and take a nap!"));
        mei.SetActive(false);
        eloise.SetActive(true);
        yield return StartCoroutine(currentDialogue("Eloise", "Rain or shine, I still don’t feel like being here honestly."));
        mei.SetActive(true);
        eloise.SetActive(false);
        yield return StartCoroutine(currentDialogue("Mei", "At least you’re with me!"));
        yield return StartCoroutine(currentDialogue("Mei", "Oh, look at the time! We are a little early."));
        mei.SetActive(false);
        eloise.SetActive(true);
        yield return StartCoroutine(currentDialogue("Eloise", "Hopefully I can catch some z’s before Miss Evelyn arrives."));
        eloise.SetActive(false);
        yield return StartCoroutine(currentDialogue("", "The two girls laugh."));
        mei.SetActive(true);
        yield return StartCoroutine(currentDialogue("Mei", "Do you like my new rings by the way? I thought they looked cute so I just had to get them."));
        mei.SetActive(false);
        eloise.SetActive(true);
        yield return StartCoroutine(currentDialogue("Eloise", "Didn’t you mention you wanted to get silver ones to match your earrings? They look good on you."));
        mei.SetActive(true);
        eloise.SetActive(false);
        yield return StartCoroutine(currentDialogue("Mei", "Hehe, I’m glad. It took forever to find something I liked so I’m happy it worked out."));
        mei.SetActive(false);
        dialogueFinished = true;
        yield return StartCoroutine(currentDialogue("", "They start making their way to the meeting room."));
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