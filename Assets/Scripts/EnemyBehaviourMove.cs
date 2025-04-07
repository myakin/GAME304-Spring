using UnityEngine;
using System.Collections;

public class EnemyBehaviourMove : EnemyBehaviour
{
    public Transform target;

    internal override IEnumerator ExecutionCoroutine() {
        if (!target) {
            target = new GameObject("target Dummy for "+gameObject.name).transform;
        }

        ChooseRandomLocation();

        if (!animator)
            animator = GetComponent<Animator>();
        animator.SetFloat("ver", 0.5f);

        float arrivalThreshold = 1.5f;
        float arrivalThresholdSqr = arrivalThreshold * arrivalThreshold;

        bool loop = true;
        while (loop) {
            Vector3 dir = target.position - transform.position; // i have to reflect this direction vector on plane of transform.forward
            
            // reflection of direction vector on steep terrain onto the plane of transform.forward
            Vector3 rightVectorForDir = Vector3.Cross(transform.up, dir.normalized);
            Vector3 forwardReflectionForDir = Vector3.Cross(rightVectorForDir, transform.up);

            // remember movment is taken care by animator (on line 17), we only rotate the enemy towards target
            // this will produce faulty measurements
            // float angle = Vector3.SignedAngle(transform.forward, dir, transform.up); 

            // this is the proper way to do it
            float angle = Vector3.SignedAngle(transform.forward, forwardReflectionForDir, transform.up);

            if (angle < -5 || angle > 5) {
                transform.rotation *= Quaternion.Euler(0, angle < 0 ? -0.2f : 0.2f, 0);
            }

            // how do we know we arrive?
            if (dir.sqrMagnitude < arrivalThresholdSqr) {
                gameObject.AddComponent<EnemyBehaviourIdle>();
                Destroy(this);
            }

            yield return null;
        }
    }

    private void ChooseRandomLocation() {
        Transform parentObject = GetComponentInParent<EnemyGroupManager>().transform;
        float radius = parentObject.GetComponent<SphereCollider>().radius;
        
        float randomDistance = Random.Range(10, radius - 10);
        float randomDirectionAngle = Random.Range(0, 359);

        Vector3 pos = parentObject.position + (Quaternion.Euler(0, randomDirectionAngle, 0) * (parentObject.forward * randomDistance));

        RaycastHit hit;
        if (Physics.Raycast(pos + Vector3.up * 500, Vector3.down, out hit, 5000, 1<<0, QueryTriggerInteraction.Ignore)) {
            target.position = hit.point;
            return;
        }
        target.position = pos;
    }

    
}
