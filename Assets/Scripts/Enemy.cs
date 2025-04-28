using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Enemy will have following states
    // idle state: idle animation + decide to move or stay idle after sometime.
    // move state: pick a random point on terrain and walk towards there, when arrived switch to idle state.
    // chase state: player is detected and now running through player. if player is too far to chase go to idle state.
    // attact state: if distance to player is smaller than a threshold, we will attack. if bigger, go back chase state
    private Animator animator;

    public void Initialize() {
        animator = GetComponent<Animator>();
        ResetAnimator();
        animator.enabled = true;
    }

    public void CompletelyDeactivate() {
        animator.enabled = false;
    }

    public void ActivateBehaviour() {
        if (!GetComponent<EnemyBehaviourIdle>()) {
            gameObject.AddComponent<EnemyBehaviourIdle>();
            GetComponent<EnemyBehaviourIdle>().ExecuteState();
        }
        if (GetComponent<AdaptToTerrain>()) {
            GetComponent<AdaptToTerrain>().StartGroundRaycasting();
        }
    }

    public void DeactivateBehaviour() {
        if (GetComponent<EnemyBehaviourIdle>()) {
            Destroy(GetComponent<EnemyBehaviourIdle>());
        }
        if (GetComponent<EnemyBehaviourMove>()) {
            Destroy(GetComponent<EnemyBehaviourMove>());
        }
        if (GetComponent<EnemyBehaviourAttack>()) {
            Destroy(GetComponent<EnemyBehaviourAttack>());
        }
        if (GetComponent<EnemyBehaviourChase>()) {
            Destroy(GetComponent<EnemyBehaviourChase>());
        }
        if (GetComponent<AdaptToTerrain>()) {
            GetComponent<AdaptToTerrain>().StopGroundRaycasting();
        }
        ResetAnimator();   
    }

    private void ResetAnimator() {
        animator.SetBool("attack", false);
        animator.SetFloat("ver", 0);
    }

    public void SetEnemy(Transform anEnemy) {
        GetComponent<EnemyBehaviour>().SetEnemy(anEnemy);
    }

    public void ReleaseEnemy() {
        GetComponent<EnemyBehaviour>().ReleaseEnemy();
    }
    
}
