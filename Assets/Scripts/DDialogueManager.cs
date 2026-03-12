using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DDialogueManager : MonoBehaviour
{
    public GameObject fadeTransition;
    public GameObject mainText;
    public GameObject charName;
    [SerializeField] GameObject textBox;
    [SerializeField] private SMDialogueAutoNext autoNext;


    public bool skip = false;

    public GameObject classroom;
    public GameObject bathroom;


    // clues reference
    public ClueData Clue1;



    void Start()
    {
        classroom.SetActive(true);
        bathroom.SetActive(false);
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

        //yield return StartCoroutine(currentDialogue("", 5, "You and Mei run into the school as the rain outside poors down, at least you're early for the student council meeting."));
        //yield return StartCoroutine(currentDialogue("", 4, "Mei mumbles something under her breath as you two reach the empty meeting room."));
        //yield return StartCoroutine(currentDialogue("Mei", 6, "I can’t believe someone messed with the club’s budget… I have to ask them about this before the meeting starts."));
        //yield return StartCoroutine(currentDialogue("You", 2, "Something wrong?"));
        //yield return StartCoroutine(currentDialogue("Mei", 5, "Oh it’s nothing, Eloise! Anyways I’ll be back, just going to go to the washroom."));
        //yield return StartCoroutine(currentDialogue("", 5, "Mei scurries deeper into the hallway in the direction of the bathroom. You head into the meeting room and wait."));
        //yield return StartCoroutine(currentDialogue("", 5, "Before you know it, you suddenly hear a blood-curdling scream. It came from the bathroom."));
        yield return StartCoroutine(currentDialogue("", 8, "Rain pours outside as you wait for the student council meeting to start. No one else was in the room just yet."));
        yield return StartCoroutine(currentDialogue("", 8, "Suddenly, a blood-curdling scream pierecd through the hallway. It sounded like it came from the bathroom."));

        bathroom.SetActive(true);
        classroom.SetActive(false);
        yield return StartCoroutine(currentDialogue("", 8, "You push open the bathroom doors. There you find your best friend Mei's lifeless body with a bite mark on her neck."));
        yield return StartCoroutine(currentDialogue("", 8, "Panic sets in and you look around, some pieces of bloody, torn up paper catch your eye."));
        //SceneManager.LoadSceneAsync("[Next Scene]");

        // unlock clue here

        // UNLOCK CLUE HERE
        if (ClueManager.Instance != null && Clue1 != null)
        {
            ClueManager.Instance.UnlockClue(Clue1);
        }

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

        while(time < num)
        {
            if(skip == true)
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
