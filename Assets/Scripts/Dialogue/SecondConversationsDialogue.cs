using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondConversationsDialogue : MonoBehaviour
{
    public GameObject fadeInTransition;
    [SerializeField] GameObject textBox;
    public GameObject mainText;
    public GameObject charName;

    public bool skipped = false;

    public bool dialogueFinished = false;
    public string nextSceneName = "23-GuessTheVampire";

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


    // Start is called before the first frame update
    void Start()
    {
        fadeInTransition.SetActive(true);
        mainText.SetActive(false);
        textBox.SetActive(false);

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

        StartCoroutine(DialogueStart());

    }

    IEnumerator DialogueStart()
    {
        yield return new WaitForSeconds(2);
        fadeInTransition.SetActive(false);
        yield return new WaitForSeconds(1);
        textBox.SetActive(true);
        mainText.SetActive(true);
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
