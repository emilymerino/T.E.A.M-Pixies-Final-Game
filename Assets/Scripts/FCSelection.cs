using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FCSelection : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (gameObject.CompareTag("Lou"))
        {
            Debug.Log("You Clicked Lou");
        }
        else if (gameObject.CompareTag("Archie"))
        {
            Debug.Log("You Clicked Archie");
        }
        else if (gameObject.CompareTag("Quinton"))
        {
            Debug.Log("You Clicked Quinton");
        }
        else if (gameObject.CompareTag("MissEvelyn"))
        {
            Debug.Log("You Clicked Miss Evelyn");
        }
        else if (gameObject.CompareTag("Zeke"))
        {
            Debug.Log("You Clicked Zeke");
        }
    }
}
