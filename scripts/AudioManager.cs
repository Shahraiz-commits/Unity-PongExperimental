using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    void Awake(){
        foreach(Sound s in sounds){
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.pitch = s.pitch;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
        }
    }
    public void Play(String name){
            Sound s = Array.Find(sounds, sound => sound.name == name);
            s.source.Play();
    }

    public void Stop(String name){
            Sound s = Array.Find(sounds, sound => sound.name == name);
            s.source.Stop();
    }
}
