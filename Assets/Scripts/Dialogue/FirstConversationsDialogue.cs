using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FirstConversationsDialogue : MonoBehaviour
{

    public GameObject fadeTransition;
    [SerializeField] GameObject textBox;
    public GameObject mainText;
    public GameObject charName;
    public GameObject startingNextButton;
    public GameObject interactionNextButton;

    public bool skipped = false;

    public GameObject louInteraction;
    public GameObject archieInteraction;
    public GameObject quintonInteraction;
    public GameObject zekeInteraction;
    public GameObject missEvelynInteraction;
    public GameObject louGlow;
    public GameObject archieGlow;
    public GameObject quintonGlow;
    public GameObject zekeGlow;
    public GameObject missEvelynGlow;

    public bool louTalked;
    public bool archieTalked;
    public bool quintonTalked;
    public bool zekeTalked;
    public bool missEvelynTalked;

    public GameObject eloise;
    public GameObject lou;
    public GameObject archie;
    public GameObject quinton;
    public GameObject zeke;
    public GameObject missEvelynNeutral;
    public GameObject missEvelynStern;

    // Start is called before the first frame update
    void Start()
    {
        fadeTransition.SetActive(true);
        mainText.SetActive(false);
        textBox.SetActive(false);
        startingNextButton.SetActive(true);
        interactionNextButton.SetActive(false);

        louInteraction.SetActive(false);
        archieInteraction.SetActive(false);
        quintonInteraction.SetActive(false);
        zekeInteraction.SetActive(false);
        missEvelynInteraction.SetActive(false);
        louGlow.SetActive(false);
        archieGlow.SetActive(false);
        quintonGlow.SetActive(false);
        zekeGlow.SetActive(false);
        missEvelynGlow.SetActive(false);

        louTalked = false;
        archieTalked = false;
        quintonTalked = false;
        zekeTalked = false;
        missEvelynTalked = false;

        eloise.SetActive(false);
        lou.SetActive(false);
        archie.SetActive(false);
        quinton.SetActive(false);
        zeke.SetActive(false);
        missEvelynNeutral.SetActive(false);
        missEvelynStern.SetActive(false);


        StartCoroutine(DialogueStart());
        StartCoroutine(continueStory());
        //***Load next scene after player talks to all characters***
    }

    IEnumerator continueStory()
    {
        mainText.SetActive(false);
        textBox.SetActive(false);
        startingNextButton.SetActive(false);
        interactionNextButton.SetActive(true);

        louInteraction.SetActive(true);
        archieInteraction.SetActive(true);
        quintonInteraction.SetActive(true);
        zekeInteraction.SetActive(true);
        missEvelynInteraction.SetActive(true);
        louGlow.SetActive(true);
        archieGlow.SetActive(true);
        quintonGlow.SetActive(true);
        zekeGlow.SetActive(true);
        missEvelynGlow.SetActive(true);

        yield return new WaitUntil(() => louTalked && archieTalked && quintonTalked && zekeTalked && missEvelynTalked);
    }

    IEnumerator DialogueStart()
    {
        fadeTransition.SetActive(true);
        mainText.SetActive(false);
        textBox.SetActive(false);
        interactionNextButton.SetActive(false);

        louInteraction.SetActive(false);
        archieInteraction.SetActive(false);
        quintonInteraction.SetActive(false);
        zekeInteraction.SetActive(false);
        missEvelynInteraction.SetActive(false);
        louGlow.SetActive(false);
        archieGlow.SetActive(false);
        quintonGlow.SetActive(false);
        zekeGlow.SetActive(false);
        missEvelynGlow.SetActive(false);

        louTalked = false;
        archieTalked = false;
        quintonTalked = false;
        zekeTalked = false;
        missEvelynTalked = false;

        eloise.SetActive(false);
        lou.SetActive(false);
        archie.SetActive(false);
        quinton.SetActive(false);
        zeke.SetActive(false);
        missEvelynNeutral.SetActive(false);
        missEvelynStern.SetActive(false);



        yield return new WaitForSeconds(2);
        fadeTransition.SetActive(false);
        yield return new WaitForSeconds(1);
        textBox.SetActive(true);
        mainText.SetActive(true);

        yield return StartCoroutine(currentDialogue("", "When Eloise enters back into the meeting room, everyone turned their heads towards the door."));
        yield return StartCoroutine(currentDialogue("", "It seemed like the meeting already started."));
        missEvelynNeutral.SetActive(true);
        yield return StartCoroutine(currentDialogue("Miss Evelyn", "You're late."));
        eloise.SetActive(true);
        missEvelynNeutral.SetActive(false);
        yield return StartCoroutine(currentDialogue("Eloise", "Mei... Mei was murdered."));
        eloise.SetActive(false);
        yield return StartCoroutine(currentDialogue("", "The room froze."));
        yield return StartCoroutine(currentDialogue("", "A beat passes before the room explodes."));
        lou.SetActive(true);
        yield return StartCoroutine(currentDialogue("Lou", "Wait… like actually murdered?"));
        lou.SetActive(false);
        quinton.SetActive(true);
        yield return StartCoroutine(currentDialogue("Quinton", "That’s not funny, Eloise."));
        quinton.SetActive(false);
        archie.SetActive(true);
        yield return StartCoroutine(currentDialogue("Archie", "This can’t be real…"));
        archie.SetActive(false);
        zeke.SetActive(true);
        yield return StartCoroutine(currentDialogue("Zeke", "Are you serious?"));
        zeke.SetActive(false);
        missEvelynStern.SetActive(true);
        yield return StartCoroutine(currentDialogue("Miss Evelyn", "Everyone, quiet."));
        missEvelynStern.SetActive(false);
        yield return StartCoroutine(currentDialogue("", "The room went still once more."));
        missEvelynNeutral.SetActive(true);
        yield return StartCoroutine(currentDialogue("Miss Evelyn", "I’ll call the authorities about the situation. Everyone will remain here while I do so."));
        missEvelynNeutral.SetActive(false);
        yield return StartCoroutine(currentDialogue("", "Everyone nervously shifts where they are, not one of them wanting to break the tense silence."));
        yield return StartCoroutine(currentDialogue("", "Maybe this is a good time to talk to them one-on-one and get information."));
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
