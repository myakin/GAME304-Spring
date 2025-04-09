using UnityEngine;

public class SoundsForObject : MonoBehaviour
{
    public AudioSource audioSource;

    public void PlaySound() {
        audioSource.Play();
    }

    public void PlayFootstepSound() {
        PlaySound();
    }
}
