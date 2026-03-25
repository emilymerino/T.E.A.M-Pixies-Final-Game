using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FCSelection2 : MonoBehaviour
{
    public SecondConversationsDialogue conversation;

    [SerializeField] GameObject textBox;
    public GameObject mainText;
    public GameObject charName;

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

    public GameObject eloiseNeutral;
    public GameObject eloiseSuspicious;
    public GameObject louNeutral;
    public GameObject louLookingOff;
    public GameObject louNervous;
    public GameObject archieNeutral;
    public GameObject archieSurprised;
    public GameObject archieDarken;
    public GameObject quintonNeutral;
    public GameObject quintonShocked;
    public GameObject zekeNeutral;
    public GameObject zekeNervous;
    public GameObject missEvelyn;

    void Start()
    {
        conversation = GetComponent<SecondConversationsDialogue>();
    }

    private void OnMouseDown()
    {
        if (gameObject.CompareTag("Lou"))
        {
            Debug.Log("You Clicked Lou");
            conversation.StartCoroutine(conversation.louConversation());
        }
        else if (gameObject.CompareTag("Archie"))
        {
            Debug.Log("You Clicked Archie");
            conversation.StartCoroutine(conversation.archieConversation());
        }
        else if (gameObject.CompareTag("Quinton"))
        {
            Debug.Log("You Clicked Quinton");
            conversation.StartCoroutine(conversation.quintonConversation());
        }
        else if (gameObject.CompareTag("MissEvelyn"))
        {
            Debug.Log("You Clicked Miss Evelyn");
            conversation.StartCoroutine(conversation.missEvelynConversation());
        }
        else if (gameObject.CompareTag("Zeke"))
        {
            Debug.Log("You Clicked Zeke");
            conversation.StartCoroutine(conversation.zekeConversation());
        }
    }
}
