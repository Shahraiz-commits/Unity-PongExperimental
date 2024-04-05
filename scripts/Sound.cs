using UnityEngine.Audio;
using UnityEngine;
using System;

[Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    [Range(0.3f,2f)]
    public float pitch;
    [Range(0f,1f)]
    public float volume;
    [HideInInspector]
    public AudioSource source;
    public bool loop;
}
