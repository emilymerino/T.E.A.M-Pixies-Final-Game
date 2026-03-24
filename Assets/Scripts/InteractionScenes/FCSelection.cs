using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FCSelection : MonoBehaviour
{
    public FirstConversationsDialogue conversation;

    void Start()
    {
        conversation = GetComponent<FirstConversationsDialogue>();
    }


    private void OnMouseDown()
    {
        if (gameObject.CompareTag("Lou"))
        {
            Debug.Log("You Clicked Lou");
            StartCoroutine(conversation.louConversation());
        }
        else if (gameObject.CompareTag("Archie"))
        {
            Debug.Log("You Clicked Archie");
            StartCoroutine(conversation.archieConversation());
        }
        else if (gameObject.CompareTag("Quinton"))
        {
            Debug.Log("You Clicked Quinton");
            StartCoroutine(conversation.quintonConversation());
        }
        else if (gameObject.CompareTag("MissEvelyn"))
        {
            Debug.Log("You Clicked Miss Evelyn");
            StartCoroutine(conversation.missEvelynConversation());
        }
        else if (gameObject.CompareTag("Zeke"))
        {
            Debug.Log("You Clicked Zeke");
            StartCoroutine(conversation.zekeConversation());
        }
    }

}
