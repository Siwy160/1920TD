
using System;
using UnityEngine;

[Serializable]
public class Sound
{
    public AudioClip sound;

    [Range(0f, 1f)]
    public float volume = 1f;
}