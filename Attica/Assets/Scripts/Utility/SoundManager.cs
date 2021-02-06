using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public SoundManager instance;

    public Sound[] sounds;


    private void Awake()
    {
        instance = this;


        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void play (string name)
    {
        Sound s = Array.Find(sounds, Sound => Sound.name == name);

        if (s == null)
            return;

        s.source.Play();
    }
}
