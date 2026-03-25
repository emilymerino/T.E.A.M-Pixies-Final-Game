using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondBathroomDialogue : MonoBehaviour
{
    public GameObject fadeInTransition;
    public GameObject fadeOutTransition;
    public GameObject fadeInAndOut;
    [SerializeField] GameObject textBox;
    public GameObject mainText;
    public GameObject charName;
    public GameObject endingText;

    public bool skipped = false;

    public bool dialogueFinished = false;
    public string nextSceneName = "1-MainMenu";

    public GameObject eloise;
    public GameObject lou;

    // Start is called before the first frame update
    void Start()
    {
        fadeInTransition.SetActive(true);
        fadeOutTransition.SetActive(false);
        fadeInAndOut.SetActive(false);
        mainText.SetActive(false);
        textBox.SetActive(false);
        endingText.SetActive(false);

        eloise.SetActive(false);
        lou.SetActive(false);

        StartCoroutine(DialogueStart());

    }

    IEnumerator DialogueStart()
    {
        yield return new WaitForSeconds(2);
        fadeInTransition.SetActive(false);
        yield return new WaitForSeconds(1);
        textBox.SetActive(true);
        mainText.SetActive(true);

        yield return StartCoroutine(currentDialogue("", "Eloise looks around the bathroom once more but only Mei's lifeless body could be seen."));
        fadeInAndOut.SetActive(true);
        yield return StartCoroutine(currentDialogue("", "A sudden sound of the door opening catches Eloise off-guard. But before she could react, a sharp pain sinks into her neck."));
        lou.SetActive(true);
        yield return StartCoroutine(currentDialogue("Lou", "Don’t take it too personal. You’re just being too noisy for your own good."));
        lou.SetActive(false);
        yield return StartCoroutine(currentDialogue("", "Eloise falls to the floor next to Mei’s body. Blood pooled on the ground mixing together with Mei’s."));
        yield return StartCoroutine(currentDialogue("", "She wanted to ask why. Why would she do this but she couldn’t get a word out as Lou walks out of the bathroom."));
        yield return StartCoroutine(currentDialogue("", "Black spots form around her vision. Tears started streaming down her face, making her world blur even more."));
        eloise.SetActive(true);
        yield return StartCoroutine(currentDialogue("Eloise", "<i>I’m sorry Mei… I’m sorry I couldn’t get justice for you.</i>"));
        eloise.SetActive(false);
        fadeOutTransition.SetActive(true);
        yield return StartCoroutine(currentDialogue("", "Eloise’s vision goes black."));
        dialogueFinished = true;
        textBox.SetActive(false);
        mainText.SetActive(false);
        yield return new WaitForSeconds(2);
        endingText.SetActive(true);
        yield return new WaitForSeconds(5);
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
