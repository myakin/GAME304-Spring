using UnityEngine;
using System.Collections;

public class EnemyBehaviourChase : MonoBehaviour
{
    private Animator animator;
    private IEnumerator executionCoroutine;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    public void ExecuteState() {
        if (executionCoroutine == null) {
            executionCoroutine = ExecutionCoroutine();
            StartCoroutine(executionCoroutine);
        }
    }

    private IEnumerator ExecutionCoroutine() {
        bool loop = true;
        while (loop) {

            yield return null;
        }
    }
}
