using System.Collections;
using System.Collections.Generic; //Remove unused namespaces
using UnityEngine;

//load in loadingscreen?
public class AudioManager : MonoBehaviour
{
    public AudioSource effectSource;
    public AudioSource musicSource;

    public static AudioManager Instance = null; // uppercase I on variable name. Make into property?

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

    public void Play(AudioClip clip) //Make enum for the different sound effects and only have 1 play method taking in a audioType as a parameter
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
