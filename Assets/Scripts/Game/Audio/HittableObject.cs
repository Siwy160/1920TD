
using System.Collections;
using UnityEngine;

public class HittableObject : MonoBehaviour
{

    [Header("Audio")]
    [SerializeField] private Sound[] hitReceivedSounds;

    [SerializeField] private AudioSourcePool audioSourcePool;
    protected AudioSource movementAudioSource;

    virtual internal void Start()
    {
        movementAudioSource = gameObject.AddComponent<AudioSource>();
    }

    virtual internal void OnHit(float damage)
    {
        PlayRandomSound(hitReceivedSounds);
    }

    protected void PlayRandomSound(Sound[] sounds)
    {
        if (sounds.Length == 0)
        {
            Debug.LogWarning("No sounds to play");
            return;
        }
        int soundIndex = Random.Range(0, sounds.Length);
        StartCoroutine(playSound(sounds[soundIndex]));
    }

    protected IEnumerator PlayRandomSoundRepeately(Sound[] sounds)
    {

        if (sounds.Length == 0)
        {
            Debug.LogWarning("No sounds to play");
            yield return null;
        }
        else
        {
            int soundIndex = Random.Range(0, sounds.Length);
            Sound sound = sounds[soundIndex];
            movementAudioSource.PlayOneShot(sound.sound, sound.volume);
            yield return new WaitWhile(() => movementAudioSource.isPlaying);
            StartCoroutine(PlayRandomSoundRepeately(sounds));
        }
    }

    private IEnumerator playSound(Sound sound)
    {
        AudioSource source = audioSourcePool.GetAudioSource();
        if (source != null)
        {
            source.PlayOneShot(sound.sound, 1f);
            yield return new WaitWhile(() => source.isPlaying);
            audioSourcePool.Release(source);
        }
        else
        {
            Debug.LogWarning("No audio sources available to play sound!");
        }
    }
}