using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHover : MonoBehaviour
{
    public Button button;
    public Color hoverColour;
    private Color originalColour;
    private ColorBlock cb;

    // Start is called before the first frame update
    void Start()
    {
        cb = button.colors;
        originalColour = cb.selectedColor;
    }

    public void hoverOver()
    {
        cb.selectedColor = hoverColour;
        button.colors = cb;
    }

    public void hoverOff()
    {
        cb.selectedColor = originalColour;
        button.colors = cb;
    }
}
