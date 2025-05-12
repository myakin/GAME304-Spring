using UnityEngine;
using System.Collections;

public class EnemyBehaviourDeath : EnemyBehaviour
{
    internal override IEnumerator ExecutionCoroutine() {
        Debug.Log("Death state execution");

        animator = GetComponent<Animator>();
        int animationChoice = Random.Range(0, 2);
        if (animationChoice==0)
            animator.SetFloat("dieAnimationChoice", -1);
        else 
            animator.SetFloat("dieAnimationChoice", 1);
        
        animator.SetTrigger("Die");
        animator.SetFloat("ver", 0);

        yield return new WaitForSeconds(240f);

        Destroy(gameObject);
    }

}
