using System.Collections.Generic;
using UnityEngine;

public class AudioSourcePool : MonoBehaviour
{
    private Queue<PoolElement> audioSources;
    [SerializeField] private int size = 10;

    // Start is called before the first frame update
    void Start()
    {
        audioSources = new Queue<PoolElement>(size);
        for (int i = 0; i < size; i++)
        {
            PoolElement element = new PoolElement();
            element.audioSource = gameObject.AddComponent<AudioSource>();
            audioSources.Enqueue(element);
        }
    }

    public AudioSource GetAudioSource()
    {
        PoolElement audio = audioSources.Dequeue();
        if (audio.InUse)
        {
            return null;
        }
        audio.InUse = true;
        audioSources.Enqueue(audio);
        return audio.audioSource;
    }

    public void Release(AudioSource audio)
    {
        foreach (PoolElement element in audioSources)
        {
            if (element.audioSource == audio)
            {
                element.InUse = false;
                return;
            }
        }
    }

    private class PoolElement
    {
        public AudioSource audioSource = null;
        public bool InUse = false;
    }
}
