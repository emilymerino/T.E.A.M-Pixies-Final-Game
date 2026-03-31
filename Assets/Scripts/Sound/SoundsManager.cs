using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{

    public static SoundsManager Instance;

    public AudioSource musicSource; // music 

    public AudioSource ambienceSource; // rain background sounds

    public AudioSource sfxSource; // will store short sound effects

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // keeping continuations on scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusic(AudioClip clip)
    {
        // not restartign

        if (musicSource.clip == clip) return;

        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlayAmbience(AudioClip clip)
    {
        // don't restart if same ambience
        if (ambienceSource.clip == clip) return;

        ambienceSource.clip = clip;
        ambienceSource.loop = true;
        ambienceSource.Play();
    }


    public void StopAmbience()
    {
        ambienceSource.Stop();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void PlayMusicImmediate(AudioClip newClip)
    {
        StopAllCoroutines();  
        musicSource.Stop();
        musicSource.clip = newClip;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlayMusicWithFade(AudioClip newClip, float duration)
    {
        StartCoroutine(FadeMusic(newClip, duration));
    }

    IEnumerator FadeMusic(AudioClip newClip, float duration)
    {
        float startVolume = musicSource.volume;

        while (musicSource.volume > 0)
        {
            musicSource.volume -= startVolume * Time.deltaTime / duration;
            yield return null;
        }

        musicSource.Stop();
        musicSource.clip = newClip;
        musicSource.Play();

        while (musicSource.volume < startVolume)
        {
            musicSource.volume += startVolume * Time.deltaTime / duration;
            yield return null;
        }

        musicSource.volume = startVolume;
    }


    public void StopAmbienceWithFade(float duration)
    {
        StartCoroutine(FadeOutAmbience(duration));
    }

    IEnumerator FadeOutAmbience(float duration)
    {
        float startVolume = ambienceSource.volume;

        while (ambienceSource.volume > 0)
        {
            ambienceSource.volume -= startVolume * Time.deltaTime / duration;
            yield return null;
        }

        ambienceSource.Stop();
        ambienceSource.volume = startVolume;
    }

}
