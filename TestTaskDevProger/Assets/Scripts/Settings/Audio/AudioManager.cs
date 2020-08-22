using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    private AudioSource _audio;

    private void Awake()
    {
        if (!Instance) Instance = this;

        else
            Destroy(gameObject);

            DontDestroyOnLoad(this);
        
    }

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    public void DisableMusic()
    {
        _audio.Pause();
    }

    public void EnableMusic()
    {
        _audio.UnPause();
    }
}
