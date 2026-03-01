using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public GameObject fadeTransition;
    public GameObject mainText;
    public GameObject charName;
    public bool skip = false;

    [SerializeField] GameObject textBox;

    void Start()
    {
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
        yield return StartCoroutine(currentDialogue("", 5, "You and Mei run into the school as the rain outside poors down, at least you're early for the student council meeting."));
        yield return StartCoroutine(currentDialogue("", 4, "Mei mumbles something under her breath as you two reach the empty meeting room."));
        yield return StartCoroutine(currentDialogue("Mei", 6, "I can’t believe someone messed with the club’s budget… I have to ask them about this before the meeting starts"));
        yield return StartCoroutine(currentDialogue("You", 2, "Something wrong?"));
        yield return StartCoroutine(currentDialogue("Mei", 5, "Oh it’s nothing, Eloise! Anyways I’ll be back, just going to go to the washroom."));
        yield return StartCoroutine(currentDialogue("", 5, "Mei scurries deeper into the hallway in the direction of the bathroom. You head into the meeting room and wait."));
        yield return StartCoroutine(currentDialogue("", 5, "Before you know it, you suddenly hear a blood-curdling scream. It came from the bathroom."));
        yield return StartCoroutine(currentDialogue("", 6, "You hurry to down the hall and pushed open the bathroom doors. There you find Mei's lifeless body with a bite mark on her neck."));
        yield return StartCoroutine(currentDialogue("", 5, "Panic sets in and you look around, some pieces of bloody, torn up paper catch your eye."));
    }

    IEnumerator currentDialogue(string name, int num, string dialogue)
    {
        int time = 0;
        mainText.GetComponent<TMPro.TMP_Text>().text = dialogue;
        charName.GetComponent<TMPro.TMP_Text>().text = name;

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
    }

}
