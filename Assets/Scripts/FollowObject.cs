using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public Transform target;
    public bool byPass = true;

    private void Update() {
        if (byPass)
            return;
        transform.position = target.position;
        transform.rotation = target.rotation;
    }
}
