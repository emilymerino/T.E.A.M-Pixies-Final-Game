using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class MouseHighlight : MonoBehaviour
{
    private Material[] materials;
    private Color[] originalColors;

    [SerializeField] private Color highlightColor = new Color(0.5f, 0.5f, 0.5f, 1f);

    // reference to global volume (drag in inspector)
    [SerializeField] private Volume globalVolume;
    private Bloom bloom;

    void Start()
    {
        // get materials
        Renderer renderer = GetComponent<Renderer>();
        materials = renderer.materials;

        originalColors = new Color[materials.Length];

        // store original emission colors
        for (int i = 0; i < materials.Length; i++)
        {
            if (materials[i].IsKeywordEnabled("_EMISSION"))
            {
                originalColors[i] = materials[i].GetColor("_EmissionColor");
            }
            else
            {
                originalColors[i] = Color.black;
            }
        }

        // get bloom from global volume
        if (globalVolume != null && globalVolume.profile.TryGet(out bloom))
        {
            Debug.Log("Bloom found");
        }
    }

    void OnMouseEnter()
    {
        Debug.Log("Enter");

        // turn on emission
        foreach (var mat in materials)
        {
            mat.EnableKeyword("_EMISSION");
            mat.SetColor("_EmissionColor", highlightColor);
        }

        // turn ON bloom (like checking box)
        if (bloom != null)
        {
            bloom.active = true;
        }
    }

    void OnMouseExit()
    {
        Debug.Log("Exit");

        // turn off emission
        for (int i = 0; i < materials.Length; i++)
        {
            materials[i].SetColor("_EmissionColor", originalColors[i]);

            if (originalColors[i] == Color.black)
            {
                materials[i].DisableKeyword("_EMISSION");
            }
        }

        // turn OFF bloom (like unchecking box)
        if (bloom != null)
        {
            bloom.active = false;
        }
    }
}