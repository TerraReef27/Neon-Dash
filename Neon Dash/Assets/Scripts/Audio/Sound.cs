using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    [System.Serializable]
    public enum soundType {music, sfx};

    public string name;

    public soundType type;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    public float pitch;

    public bool looping;
    
    public AudioSource source;
}
