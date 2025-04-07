using UnityEngine;
using System.Collections;

public class EnemyBehaviourIdle : EnemyBehaviour
{
    internal override void Start() {
        animator = GetComponent<Animator>();
        ResetAnimator();
    }
    
    internal override IEnumerator ExecutionCoroutine() {
        bool loop = true;
        while (loop) {
            yield return new WaitForSeconds(10);

            int willMove = Random.Range(0, 2);
            if (willMove == 1) { // we will move
                gameObject.AddComponent<EnemyBehaviourMove>();
                GetComponent<EnemyBehaviourMove>().ExecuteState();
                Destroy(this);
            }
        }
    }


}
