using UnityEngine;

public class DroppedItemPhysics : MonoBehaviour
{
    private Rigidbody rb;
    private float timer;

    private void Start() {
        rb = gameObject.AddComponent<Rigidbody>();
    }
    private void Update() {
        timer += Time.deltaTime;
        if (rb.linearVelocity == Vector3.zero && rb.angularVelocity == Vector3.zero && timer > 3) {
            Destroy(rb);
            Destroy(this);
        }
    }
}
