using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LCStatusLightsBehaviour : MonoBehaviour
{
    public List<SpriteRenderer> statusLightsList;

    void Start()
    {
        if (statusLightsList == null) return;

        foreach (SpriteRenderer statusLight in statusLightsList)
        {
            if (statusLight != null)
            {
                statusLight.enabled = false; // starts hidden
            }
        }
    }

    void Update()
    {
        
    }
}
