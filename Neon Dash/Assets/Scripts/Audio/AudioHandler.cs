using UnityEngine;
using UnityEngine.Audio;

public class AudioHandler : MonoBehaviour
{
    public static AudioHandler instance = null;

    [SerializeField] private AudioMixer mixer = null;
    [SerializeField] private AudioSource[] audioSources;
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        mixer.SetFloat("masterVolume", PlayerPrefs.GetFloat("MasterVolume"));
        mixer.SetFloat("sfxVolume", PlayerPrefs.GetFloat("SfxVolume"));
        mixer.SetFloat("musicVolume", PlayerPrefs.GetFloat("MusicVolume"));
    }

    public void PlaySound(string soundName)
    {
        foreach (AudioSource s in audioSources)
        {
            if(s.name == soundName)
            {
                s.Play();
                return;
            }
        }

        Debug.Log("error finding sound");
        return;
    }

    public void SetMixerLevel(string mixerName, float newVolume)
    {
        mixer.SetFloat(mixerName, newVolume);
    }
}
