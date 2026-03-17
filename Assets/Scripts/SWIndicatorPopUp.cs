using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SWIndicatorPopUp : MonoBehaviour
{
    public GameObject Indicator;

    public void Start()
    {
        Indicator.gameObject.SetActive(false); // starts hidden
    }

    public void ShowIndicator()
    {
        Indicator.gameObject.SetActive(true);
        Debug.Log("Enter");
    }
}
