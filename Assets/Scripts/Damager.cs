using UnityEngine;

public class Damager : MonoBehaviour
{
    public int damageAmount = 5;
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            other.GetComponent<HealthManager>().Reduce(damageAmount + Random.Range(-3, 4));
        }
    }
}
