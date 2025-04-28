using UnityEngine;
using System.Collections;

public class EnemyBehaviourChase : EnemyBehaviour
{

    internal override IEnumerator ExecutionCoroutine() {
        if (target) {
            if (!animator)
                animator = GetComponent<Animator>();
            animator.SetFloat("ver", 1f);

            float arrivalThreshold = 1f;
            float chaseReleaseThreshold = 10;
            float arrivalThresholdSqr = arrivalThreshold * arrivalThreshold;
            float chaseReleaseThresholdSqr = chaseReleaseThreshold * chaseReleaseThreshold;

            float chaseReleaseTimer = 0;

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
                float distanceSqr = dir.sqrMagnitude;
                if (distanceSqr < arrivalThresholdSqr) {
                    gameObject.AddComponent<EnemyBehaviourAttack>();
                    GetComponent<EnemyBehaviourAttack>().target = target;
                    GetComponent<EnemyBehaviourAttack>().ExecuteState();
                    Destroy(this);
                } else if (chaseReleaseTimer > 20 && distanceSqr > chaseReleaseThresholdSqr) {
                    gameObject.AddComponent<EnemyBehaviourIdle>();
                    GetComponent<EnemyBehaviourIdle>().ExecuteState();
                    Destroy(this);
                }
                chaseReleaseTimer += Time.deltaTime;
                
                yield return null;
            }
        } else {
            gameObject.AddComponent<EnemyBehaviourIdle>();
            Destroy(this);
        }
    }
}
