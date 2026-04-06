using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    public AudioMixer volumeMixer;
    public GameObject menuCanvas;
    public GameObject menu;

    void Start()
    {
        menu.SetActive(false);
    }

    void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(menuCanvas);
        }
        else
        {
            Destroy(gameObject);
            Destroy(menuCanvas);
            return;
        }
    }

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

    public void QuitButton()
    {
        menu.SetActive(false);

        if (ClueManager.Instance != null)
            ClueManager.Instance.ResetClueSystem();

        SceneManager.LoadScene("1-MainMenu");
    }
}
