using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Sound_Manager : MonoBehaviour
{
    private static Sound_Manager instance;
    public static Sound_Manager Instance { get { return instance; } }
    public SoundType[] soundTypes;
    public AudioSource soundEffect;
    public AudioSource soundMusic;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void Play(Sound sound)
    {
        AudioClip clip = GetSoundClip(sound);
        if (clip != null)
        {
            soundEffect.PlayOneShot(clip);
        }
    }
    private AudioClip GetSoundClip(Sound sound)
    {
        SoundType item = Array.Find(soundTypes, i => i.soundType == sound);
        if (item != null)
            return item.soundClip;

            return null;
    }
    
}
[System.Serializable]
public class SoundType 
{
    public Sound soundType;
    public AudioClip soundClip;
}

public enum Sound
{
    ButtonClick,
    PlayerMove,
    PlayerDeath,
    EnemyDeath,
    PickUp,
    PlayerJump,
    PlayerLand,
}
