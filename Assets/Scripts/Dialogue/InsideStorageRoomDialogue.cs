using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InsideStorageRoomDialogue : MonoBehaviour
{
    public GameObject fadeInTransition;
    [SerializeField] GameObject textBox;
    public GameObject mainText;
    public GameObject charName;

    public bool skipped = false;

    public bool dialogueFinished = false;
    public string nextSceneName = "19-BehindTheMess";

    // Start is called before the first frame update
    void Start()
    {
        fadeInTransition.SetActive(true);
        mainText.SetActive(false);
        textBox.SetActive(false);

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
