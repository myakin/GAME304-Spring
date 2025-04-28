using UnityEngine;
using System.Collections;

public class EnemyBehaviourAttack : EnemyBehaviour
{
    
    internal override IEnumerator ExecutionCoroutine() {
        if (!animator)
            animator = GetComponent<Animator>();
        animator.SetFloat("ver", 0);
        animator.SetBool("attack", true);

        float chaseThreshold = 2f;
        float chaseThresholdSqr = chaseThreshold * chaseThreshold;

        bool loop = true;
        while (loop) {
            if ((target.position - transform.position).sqrMagnitude > chaseThresholdSqr) {
                animator.SetBool("attack", false);
                gameObject.AddComponent<EnemyBehaviourChase>().target = target;
                GetComponent<EnemyBehaviourChase>().ExecuteState();
                Destroy(this);
            }
            yield return null;
        }
    }
}
