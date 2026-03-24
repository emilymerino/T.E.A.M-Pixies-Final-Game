using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WrongGuessEndingDialogue : MonoBehaviour
{
    public GameObject fadeInTransition;
    [SerializeField] GameObject textBox;
    public GameObject mainText;
    public GameObject charName;

    public bool skipped = false;

    public GameObject eloiseNeutral;
    public GameObject eloiseSuspicious;
    public GameObject eloiseUpset;
    public GameObject eloisePointing;
    public GameObject lou;
    public GameObject archie;
    public GameObject quinton;
    public GameObject zeke;
    public GameObject missEvelyn;

    // Start is called before the first frame update
    void Start()
    {
        fadeInTransition.SetActive(true);
        mainText.SetActive(false);
        textBox.SetActive(false);

        eloiseNeutral.SetActive(false);
        eloiseSuspicious.SetActive(false);
        eloiseUpset.SetActive(false);
        eloisePointing.SetActive(false);
        lou.SetActive(false);
        archie.SetActive(false);
        quinton.SetActive(false);
        zeke.SetActive(false);
        missEvelyn.SetActive(false);

        StartCoroutine(DialogueStart());

    }

    IEnumerator DialogueStart()
    {
        yield return new WaitForSeconds(2);
        fadeInTransition.SetActive(false);
        yield return new WaitForSeconds(1);
        textBox.SetActive(true);
        mainText.SetActive(true);

        eloiseNeutral.SetActive(true);
        yield return StartCoroutine(currentDialogue("Eloise", "The one who killed Mei..."));
        eloiseNeutral.SetActive(false);
        eloisePointing.SetActive(true);
        yield return StartCoroutine(currentDialogue("Eloise", "Has to be you!"));
        eloisePointing.SetActive(false);
        yield return StartCoroutine(currentDialogue("Everyone", "…"));
        quinton.SetActive(true);
        yield return StartCoroutine(currentDialogue("Quinton", "Um… are you sure you know what you’re talking about, Eloise?"));
        quinton.SetActive(false);
        zeke.SetActive(true);
        yield return StartCoroutine(currentDialogue("Zeke", "Y-yeah, that seems like a stretch."));
        zeke.SetActive(false);
        lou.SetActive(true);
        yield return StartCoroutine(currentDialogue("Lou", "I’ll have to agree with them."));
        lou.SetActive(false);
        archie.SetActive(true);
        yield return StartCoroutine(currentDialogue("Archie", "That just seems… really hard to believe."));
        archie.SetActive(false);
        missEvelyn.SetActive(true);
        yield return StartCoroutine(currentDialogue("Miss Evelyn", "Please refrain from making outrageous claims."));
        eloiseUpset.SetActive(true);
        missEvelyn.SetActive(false);
        yield return StartCoroutine(currentDialogue("Eloise", "<i>Why does no one believing me?</i>"));
        eloiseSuspicious.SetActive(true);
        eloiseUpset.SetActive(false);
        yield return StartCoroutine(currentDialogue("Eloise", "Fine. I’ll just have to go out and find more clues. I’ll prove that it’s you."));
        eloiseSuspicious.SetActive(false);
        yield return StartCoroutine(currentDialogue("", "Eloise storms out the room and heads back to the bathroom to investigate. There has to be something she missed."));
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
