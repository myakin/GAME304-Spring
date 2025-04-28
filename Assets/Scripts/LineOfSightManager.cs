using UnityEngine;

public class LineOfSightManager : MonoBehaviour
{
    public Enemy enemyScript;

    private void OnTriggerEnter(Collider other) {
        if (other.tag=="Player") {
            // transform.localScale = Vector3.one * (transform.localScale.x * 2);
            Debug.Log(other.tag+" entered line of sight");
            enemyScript.SetEnemy(other.transform);
        }
    }
}
