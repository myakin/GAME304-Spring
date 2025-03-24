using UnityEngine;

public class HealthManagerDelegate : MonoBehaviour
{
    public HealthManager healthManager;

    public void Reduce(int value) {
        healthManager.Reduce(value);
    }
}
