using UnityEngine;
using System.Collections;

public class AdaptToTerrain : MonoBehaviour
{
    public float raycastingInterval = 0.5f;
    private IEnumerator raycastCoroutine;

    // private void OnEnable() {
    //     StartGroundRaycasting();
    // }
    // private void OnDisable() {
    //     StopGroundRaycasting();
    // }

    public void StartGroundRaycasting() {
        if (raycastCoroutine==null) {
            raycastCoroutine = RaycastCoroutine();
            StartCoroutine(raycastCoroutine);
        }
    }

    public void StopGroundRaycasting() {
        if (raycastCoroutine!=null) {
            StopCoroutine(raycastCoroutine);
            raycastCoroutine = null;
        }
    }

    private IEnumerator RaycastCoroutine() {
        bool loop = true;
        while (loop) {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up * 2f, Vector3.down, out hit, 100, 1<<0, QueryTriggerInteraction.Ignore)) {
                transform.position = hit.point;
            }

            yield return new WaitForSeconds(raycastingInterval);
        }
    }
}
