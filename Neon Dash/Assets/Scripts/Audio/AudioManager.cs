using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance = null;

    [SerializeField] private Sound[] sounds = null;

    public float masterVolume = 1f;
    public float musicVolume = 1f;
    public float sfxVolume = 1f;
    
    void Awake()
    {
        if(instance == null)
        {
            Debug.Log("set instance");
            instance = this;
        }
        else
        {
            Debug.Log("destroying duplicate");
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(this);

        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.looping;
        }
    }

    public void PlaySound(string soundName)
    {
        //Sound s = Array.Find(sounds, sound => sound.name == name);
        foreach(Sound s in sounds)
        {
            if(s.name == soundName)
            {
                s.source.Play();
                return;
            }   
        }

        //Debug.Log("Sound: " + s.name + " was not found");
        Debug.Log("error finding sound");
    }
}
