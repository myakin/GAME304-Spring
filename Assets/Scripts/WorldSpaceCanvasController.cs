using UnityEngine;

public class WorldSpaceCanvasController : MonoBehaviour
{
    private void OnEnable() {
        GetComponent<Canvas>().worldCamera = Camera.main;
    }

    private void Update() {
        Vector3 dir = transform.position - Camera.main.transform.position;
        transform.rotation = Quaternion.LookRotation(dir, Vector3.up);
    }
}
