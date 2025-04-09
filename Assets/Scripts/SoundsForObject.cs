using UnityEngine;

public class SoundsForObject : MonoBehaviour
{
    public AudioSource audioSource;

    public void PlaySound() {
        audioSource.Play();
    }

    public void PlayFootstepSound() {
        float pitchValue = Random.Range(0.8f, 1.2f);
        audioSource.pitch = pitchValue;
        PlaySound();
    }
}
