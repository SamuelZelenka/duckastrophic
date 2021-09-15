using UnityEngine;

//load in loadingscreen?
public class AudioManager : MonoBehaviour
{
    public AudioSource effectSource;

    public static AudioManager Instance { get; private set; }

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

    public void Play(AudioClip clip)
    {
        effectSource.clip = clip;
        effectSource.Play();
    }
}
