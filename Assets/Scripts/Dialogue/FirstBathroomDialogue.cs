using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FirstBathroomDialogue : MonoBehaviour
{
    public GameObject fadeTransition;
    [SerializeField] GameObject textBox;
    public GameObject mainText;
    public GameObject charName;

    public bool skipped = false;

    public GameObject eloiseScared;
    public GameObject eloiseSuspicious;

    // Start is called before the first frame update
    void Start()
    {
        eloiseScared.SetActive(false);
        eloiseSuspicious.SetActive(false);

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


        yield return StartCoroutine(currentDialogue("", "Eloise pushes the bathroom door open. Mei is laying on the cold tile floor, pale and barely conscious."));
        yield return StartCoroutine(currentDialogue("", "Two deep puncture wounds marked her neck, blood staining the collar of her uniform."));
        eloiseScared.SetActive(true);
        yield return StartCoroutine(currentDialogue("Eloise", "Mei!! Mei, wake up!! She’s not breathing…"));
        yield return StartCoroutine(currentDialogue("Eloise", "What are these marks…? They look like bite marks."));
        yield return StartCoroutine(currentDialogue("Eloise", " No, this can’t be. Someone- or something attacked Mei. A vampire?"));
        eloiseScared.SetActive(false);
        yield return StartCoroutine(currentDialogue("", "Under her fingernails were torn threads of the school’s uniform."));
        eloiseSuspicious.SetActive(true);
        yield return StartCoroutine(currentDialogue("Eloise", "Poor Mei, she fought until the very end."));
        yield return StartCoroutine(currentDialogue("Eloise", "Whoever did this is still here."));
        eloiseSuspicious.SetActive(false);
        yield return StartCoroutine(currentDialogue("Intercom", "*Crackle*"));
        yield return StartCoroutine(currentDialogue("Intercom", "Due to the outdoor conditions, the building is placed on lockdown."));
        yield return StartCoroutine(currentDialogue("Intercom", "Please remain where you are."));
        yield return StartCoroutine(currentDialogue("Intercom", "*Crackle*"));
        yield return StartCoroutine(currentDialogue("", "With the school placed on lockdown, no one could leave."));
        yield return StartCoroutine(currentDialogue("", "Eloise looks around the bathroom. No one is there but Mei; the perpetrator ran away before she could find them."));
        yield return StartCoroutine(currentDialogue("", "Maybe there was a clue left behind that she could use."));
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
