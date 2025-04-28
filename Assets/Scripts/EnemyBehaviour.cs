using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour
{
    public Transform target;
    internal Animator animator;
    internal IEnumerator executionCoroutine;
    

    internal virtual void Start() {
        animator = GetComponent<Animator>();
    }

    public virtual void ExecuteState() {
        if (executionCoroutine == null) {
            executionCoroutine = ExecutionCoroutine();
            StartCoroutine(executionCoroutine);
        }
    }

    internal virtual IEnumerator ExecutionCoroutine() {
        yield return null;
    }

    internal void ResetAnimator() {
        animator.SetBool("attack", false);
        animator.SetFloat("ver", 0);
    }

    public virtual void SetEnemy(Transform anEnemy) {
        if (target == anEnemy)
            return;
        target = anEnemy;
        if (GetComponent<EnemyBehaviourIdle>() || GetComponent<EnemyBehaviourMove>()) {
            ChaseTarget();
        }
    }
    public virtual void ReleaseEnemy() {
        target = null;
    }

    public virtual void ChaseTarget() {
        Debug.Log("Adding chase state");
        gameObject.AddComponent<EnemyBehaviourChase>();
        GetComponent<EnemyBehaviourChase>().target = target;
        GetComponent<EnemyBehaviourChase>().ExecuteState();
        if (GetComponent<EnemyBehaviourIdle>()) {
            Destroy(GetComponent<EnemyBehaviourIdle>());
        } else if (GetComponent<EnemyBehaviourMove>()) {
            Destroy(GetComponent<EnemyBehaviourMove>());
        }
    }
}
