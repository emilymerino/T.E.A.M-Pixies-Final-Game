using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SWHoverGlow : MonoBehaviour
{
    public SWIndicatorPopUp indicatorPopUp;

    public SpriteRenderer SchoolDoorsGlow;

    void Start()
    {
        SchoolDoorsGlow.gameObject.SetActive(false); // starts hidden
    }

    void OnMouseEnter()
    {
        SchoolDoorsGlow.gameObject.SetActive(true);
        indicatorPopUp.ShowIndicator();
        Debug.Log("Enter");
    }

    void OnMouseExit()
    {
        SchoolDoorsGlow.gameObject.SetActive(false);
        Debug.Log("Exit");
    }
}
