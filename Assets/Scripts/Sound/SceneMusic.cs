using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMusic : MonoBehaviour
{
    public AudioClip music;
    public AudioClip ambience1; // rain

    void Start()
    {
        SoundsManager.Instance.PlayMusic(music);

        if (ambience1 != null)
        {
            SoundsManager.Instance.PlayAmbience(ambience1);
        }
        else
        {
            SoundsManager.Instance.StopAmbience(); // stops ambience
        }
    }
}



