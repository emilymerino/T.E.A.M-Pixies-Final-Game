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

    public ClueData Clue1;
    public ClueData Clue2;
    public ClueData Clue3;
    public ClueData Clue4;
    public ClueData Clue5;
    public ClueData Clue6;
    public ClueData Clue7;
    public ClueData Clue8;
    public ClueData Clue9;
    public ClueData Clue10;
    public ClueData Clue11;


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
        yield return StartCoroutine(currentDialogue("", "There's a note in the pocket of the blazer, “Meeting you about the missing transfers. This ends tonight. - Mei”"));
        skip = false;

        //yield return new WaitForSeconds(2);

        // unlock clue
        //ClueManager.Instance.UnlockClue(Clue8);


        yield return StartCoroutine(currentDialogue("", "You shut the locker door and glance down the hallway. You can see an open door leading to the storage room."));
        skip = false;
        lockers.SetActive(false);
        storage.SetActive(true);
        yield return StartCoroutine(currentDialogue("", "You remember that the torn note mentioned that room and you march in to see the mess around you."));
        skip = false;
        yield return StartCoroutine(currentDialogue("", "You're certain that underneath this mess, there's a clue hidden here."));
        skip = false;
        //SceneManager.LoadSceneAsync("[Next Scene]");

        // Load Next Scene
        if (autoNext != null)
        {
            autoNext.LoadNextScene();
        }
    }

    IEnumerator currentDialogue(string name, string dialogue)
    {
        mainText.GetComponent<TMP_Text>().text = dialogue;
        charName.GetComponent<TMP_Text>().text = name;

        Debug.Log("Skipped dialogue");
        yield return new WaitUntil(() => skip == true);
    }

}
