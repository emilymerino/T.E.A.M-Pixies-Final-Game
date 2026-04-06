using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MenuManager : MonoBehaviour
{
    public AudioMixer volumeMixer;

    public GameObject menu;


    public void SetVolume(float volume)
    {
        volumeMixer.SetFloat("Volume", volume);
    }

    public void CloseMenu()
    {
        menu.SetActive(false);
    }

    public void OpenMenu()
    {
        menu.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
