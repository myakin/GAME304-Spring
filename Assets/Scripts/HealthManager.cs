using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 100;

    public void Reduce(int amount) {
        currentHealth-=amount;
        if (currentHealth<0) {
            currentHealth = 0;
        }

        if (currentHealth==0) {
            // die
            
        }
    }
}
