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

    public GameObject characterSprite;
    public Sprite MissEvelyn;
    public Sprite Quinton;
    public Sprite Lou;
    public Sprite Archie;
    public Sprite Zeke;

    [SerializeField] GameObject textBox;


    void Start()
    {
        fadeTransition.SetActive(true);
        mainText.SetActive(false);
        textBox.SetActive(false);
        characterSprite.SetActive(false);
        StartCoroutine(DialogueStart());
    }

    IEnumerator DialogueStart()
    {
        yield return new WaitForSeconds(2);
        fadeTransition.SetActive(false);
        yield return new WaitForSeconds(1);
        textBox.SetActive(true);
        mainText.SetActive(true);
        yield return StartCoroutine(currentDialogue("", 8, "You pocket the note and rush back to the meeting room."));
        yield return StartCoroutine(currentDialogue("", 10, "You pull open the door. You see that the student council meeting has started."));
        characterSprite.SetActive(true);
        characterSprite.GetComponent<SpriteRenderer>().sprite = MissEvelyn;
        yield return StartCoroutine(currentDialogue("Miss Evelyn", 4, "You're late."));
        characterSprite.SetActive(false);
        yield return StartCoroutine(currentDialogue("You", 8, "M-Mei was murdered by a vampire in the bathroom."));
        yield return StartCoroutine(currentDialogue("", 8, "The room falls silent. Lou drops her pen."));
        characterSprite.SetActive(true);
        characterSprite.GetComponent<SpriteRenderer>().sprite = Lou;
        yield return StartCoroutine(currentDialogue("Lou", 4, "Wait- murdered?"));
        characterSprite.GetComponent<SpriteRenderer>().sprite = MissEvelyn;
        yield return StartCoroutine(currentDialogue("Miss Evelyn", 6, "Let's not jump to dramatic conclusions."));
        characterSprite.GetComponent<SpriteRenderer>().sprite = Archie;
        yield return StartCoroutine(currentDialogue("Archie", 8, "Hm... I heard a noise down the hall earlier around 10 minutes ago."));
        characterSprite.GetComponent<SpriteRenderer>().sprite = Quinton;
        yield return StartCoroutine(currentDialogue("Quinton", 7, "I was helping Miss Evelyn during that time."));
        characterSprite.GetComponent<SpriteRenderer>().sprite = Zeke;
        yield return StartCoroutine(currentDialogue("Zeke", 8, "The vampire thing worries me. Hey Lou, aren't you allergic to garlic?"));
        characterSprite.SetActive(false);
        yield return StartCoroutine(currentDialogue("", 8, "The room erupted into choas. Everyone was acting weird, you can't seem trust anyone."));
        yield return StartCoroutine(currentDialogue("", 8, "You quietly step out the room. Your eye catches something peeking through the cracks of a nearby locker."));
        yield return StartCoroutine(currentDialogue("", 10, "You take a closer look and you realize it's a bloody sheelve of the council blazer. You have to see what's inside this locker."));
        //SceneManager.LoadSceneAsync("[Next Scene]");
    }

    IEnumerator currentDialogue(string name, int num, string dialogue)
    {
        int time = 0;
        mainText.GetComponent<TMP_Text>().text = dialogue;
        charName.GetComponent<TMP_Text>().text = name;

        while (time < num)
        {
            if (GetComponent<SkipDialogue>().skip == true)
            {
                GetComponent<SkipDialogue>().skip = false;
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
