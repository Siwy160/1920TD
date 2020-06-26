
using System;
using UnityEngine;

[Serializable]
public class Sound
{
    public AudioClip sound;

    [Range(0f, 1f)]
    public float volume = 1f;
    [Range(-3f, 3f)]
    public float pitch = 1f;
    [Range(0, 1f)]
    public float spatialBlend = 1f;
}