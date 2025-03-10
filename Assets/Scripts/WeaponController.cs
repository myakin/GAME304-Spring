using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour
{
    public ParticleSystem fireEffect, muzzleEffect;
    public float fireRate = 2;
    public AudioClip weaponFireAudio;
    public AudioSource audioSource;

    private bool isOnHold;


    public void Fire() {
        if (!isOnHold) {
            isOnHold = true;
            muzzleEffect.Play();
            // fireEffect.Play();
            fireEffect.Emit(1);
            audioSource.PlayOneShot(weaponFireAudio);
            StartCoroutine(ReleaseHold());
        }
    }

    private IEnumerator ReleaseHold() {
        yield return new WaitForSeconds(1/fireRate);
        isOnHold = false;
    }


}
