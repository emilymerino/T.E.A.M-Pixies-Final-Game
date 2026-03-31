using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LCViewCombinationButton : MonoBehaviour
{
    public LCCombination combination;

    private ISHoverGlow hoverGlow;

    public bool isSelected = false;

    void Start()
    {
        hoverGlow = GetComponent<ISHoverGlow>();

        if (hoverGlow != null)
        {
            hoverGlow.HideGlow();
        }

        gameObject.SetActive(false);
    }

    public void OnButtonClick()
    {
        isSelected = true;

        if (combination != null)
        {
            combination.PlayCombination();
        }

        Debug.Log("Button Selected");
    }

    public void ShowViewCombinationButton()
    {
        gameObject.SetActive(true);
    }

    public void HideViewCombinationButton()
    {
        if (hoverGlow != null)
        {
            hoverGlow.HideGlow();
        }

        gameObject.SetActive(false);
    }
}