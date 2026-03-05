using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndingDialogueManager : MonoBehaviour
{
    public GameObject fadeTransition;
    public GameObject mainText;
    public GameObject charName;
    [SerializeField] GameObject textBox;
    [SerializeField] private SMDialogueAutoNext autoNext;

    public bool skip = false;

    public GameObject lockers;
    public GameObject storage;

    void Start()
    {
        lockers.SetActive(true);
        storage.SetActive(false);

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
        yield return StartCoroutine(currentDialogue("", 8, "There's a note in the pocket of the blazer, “Meeting you about the missing transfers. This ends tonight. - Mei”"));
        yield return StartCoroutine(currentDialogue("", 8, "You shut the locker door and glance down the hallway. You can see an open door leading to the storage room."));
        lockers.SetActive(false);
        storage.SetActive(true);
        yield return StartCoroutine(currentDialogue("", 8, "You remember that the torn note mentioned that room and you march in to see the mess around you."));
        yield return StartCoroutine(currentDialogue("", 8, "You're certain that underneath this mess, there's a clue hidden here."));
        //SceneManager.LoadSceneAsync("[Next Scene]");

        // Load Next Scene
        if (autoNext != null)
        {
            autoNext.LoadNextScene();
        }
    }

    IEnumerator currentDialogue(string name, int num, string dialogue)
    {
        int time = 0;
        mainText.GetComponent<TMP_Text>().text = dialogue;
        charName.GetComponent<TMP_Text>().text = name;

        while (time < num)
        {
            if (skip == true)
            {
                skip = false;
                Debug.Log("Skipped dialogue");
                yield break;
            }
            yield return new WaitForSeconds(1);
            time++;
        }
        Debug.Log("Finished dialogue");
        yield break;
    }

}
