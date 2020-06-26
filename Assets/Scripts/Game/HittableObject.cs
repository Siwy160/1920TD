
using UnityEngine;

public class HittableObject : MonoBehaviour
{

    [Header("Audo")]
    [SerializeField] private AudioSource hitReceivedSound;

    virtual internal void OnHit(float damage)
    {
        hitReceivedSound.Play();
    }
}