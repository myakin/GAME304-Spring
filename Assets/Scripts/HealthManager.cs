using UnityEngine;
using System.Collections;

public class HealthManager : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 100;
    public Canvas enemyHealthCanvas;

    private float enemyHealthCanvasTurnOffTimer;
    private IEnumerator enemyHealthCanvasTurnOffCoroutine;
    private bool isDead;

    public void Reduce(int amount) {
        currentHealth-=amount;
        if (currentHealth<0) {
            currentHealth = 0;
        }

        if (enemyHealthCanvas) {
            if (!enemyHealthCanvas.gameObject.activeSelf)
                enemyHealthCanvas.gameObject.SetActive(true);
            enemyHealthCanvas.GetComponentInChildren<Progressbar>().SetProgress(currentHealth / (float)maxHealth);

            enemyHealthCanvasTurnOffTimer = 0;
            if (enemyHealthCanvasTurnOffCoroutine == null) {
                enemyHealthCanvasTurnOffCoroutine = EmemyHealthCanvasTurnOffCoroutine();
                StartCoroutine(enemyHealthCanvasTurnOffCoroutine);
            } 
        } else {
            PlayerUIManager.instance.SetHealth(currentHealth, maxHealth);
        }

        if (currentHealth==0 && !isDead) {
            isDead = true;

            // die
            Destroy(GetComponent<EnemyBehaviour>());

            gameObject.AddComponent<EnemyBehaviourDeath>().ExecuteState();
        }
    }

    private IEnumerator EmemyHealthCanvasTurnOffCoroutine() {
        float turnOffDuration = 10;
        while (enemyHealthCanvasTurnOffTimer < turnOffDuration) {
            enemyHealthCanvasTurnOffTimer += Time.deltaTime;
            yield return null;
        }
        enemyHealthCanvas.gameObject.SetActive(false);
        enemyHealthCanvasTurnOffCoroutine = null;
    }
}
