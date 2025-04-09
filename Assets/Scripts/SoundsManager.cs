using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    public static SoundsManager instance;

    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else if (instance != null) {
            Destroy(gameObject);
        }
    }

    public AudioSource ambientSoundAudioSource;

    private void Start() {
        PlayAmbientSound();
    }

    public void PlayAmbientSound() {
        ambientSoundAudioSource.Play();
    }
}
