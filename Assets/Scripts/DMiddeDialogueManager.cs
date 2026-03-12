using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MiddeDialogueManager : MonoBehaviour
{
    public GameObject fadeTransition;
    public GameObject mainText;
    public GameObject charName;

    public bool skip = false;

    //public GameObject characterSprite;
    public GameObject missEvelyn;
    public GameObject quinton;
    public GameObject lou;
    public GameObject archie;
    public GameObject zeke;

    public GameObject classroom;
    public GameObject bathroom;
    public GameObject lockers;

    [SerializeField] GameObject textBox;
    [SerializeField] private SMDialogueAutoNext autoNext;

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
        missEvelyn.SetActive(false);
        quinton.SetActive(false);
        lou.SetActive(false);
        archie.SetActive(false);
        zeke.SetActive(false);

        classroom.SetActive(false);
        bathroom.SetActive(true);
        lockers.SetActive(false);

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

        yield return StartCoroutine(currentDialogue("", 6, "You pocket the note and rush back to the meeting room."));

        yield return new WaitForSeconds(2);

        // unlock clue
        ClueManager.Instance.UnlockClue(Clue2);


        classroom.SetActive(true);
        bathroom.SetActive(false);
        yield return StartCoroutine(currentDialogue("", 7, "You pull open the door. You see that the student council meeting has started."));
        missEvelyn.SetActive(true);
        yield return StartCoroutine(currentDialogue("Miss Evelyn", 4, "You're late."));
        missEvelyn.SetActive(false);
        yield return StartCoroutine(currentDialogue("You", 6, "M-Mei was murdered by a vampire in the bathroom."));
        yield return StartCoroutine(currentDialogue("", 5, "The room falls silent. Lou drops her pen."));
        lou.SetActive(true);
        yield return StartCoroutine(currentDialogue("Lou", 4, "Wait- murdered?"));
        lou.SetActive(false);
        missEvelyn.SetActive(true);
        yield return StartCoroutine(currentDialogue("Miss Evelyn", 6, "Let's not jump to dramatic conclusions."));


        yield return new WaitForSeconds(2);

        // unlock clue
        ClueManager.Instance.UnlockClue(Clue4);


        missEvelyn.SetActive(false);
        archie.SetActive(true);
        yield return StartCoroutine(currentDialogue("Archie", 7, "Hm... I heard a noise down the hall earlier around 10 minutes ago."));
        archie.SetActive(false);
        quinton.SetActive(true);
        yield return StartCoroutine(currentDialogue("Quinton", 7, "I was helping Miss Evelyn during that time."));
        quinton.SetActive(false);
        zeke.SetActive(true);
        yield return StartCoroutine(currentDialogue("Zeke", 7, "The vampire thing worries me. Hey Lou, aren't you allergic to garlic?"));


        yield return new WaitForSeconds(2);

        // unlock clue
        ClueManager.Instance.UnlockClue(Clue6); 


        zeke.SetActive(false);
        yield return StartCoroutine(currentDialogue("", 8, "The room erupted into choas. Everyone was acting weird, you can't seem to trust anyone."));

        classroom.SetActive(false);
        lockers.SetActive(true);
        yield return StartCoroutine(currentDialogue("", 8, "You quietly step out the room. Your eye catches something peeking through the cracks of a nearby locker."));
        yield return StartCoroutine(currentDialogue("", 10, "You take a closer look and you realize it's a bloody sleeve of the council blazer. You have to see what's inside this locker."));
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
