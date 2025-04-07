using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour
{
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
}
