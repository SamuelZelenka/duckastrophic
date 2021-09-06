using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource effectSource;
    public AudioSource musicSource;

    public static AudioManager Instance = null;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    // A simple sound effect or music trigger can be reached through AudioManager.Instance.Play(nameOfAudioClipInAudioSourceComponent);

    public void Play(AudioClip clip)
    {
        effectSource.clip = clip;
        effectSource.Play();
    }

    public void PlayMusic (AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
    }
}
