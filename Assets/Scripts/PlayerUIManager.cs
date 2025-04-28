using UnityEngine;
using TMPro;

public class PlayerUIManager : MonoBehaviour
{
    public static PlayerUIManager instance;

    private void Awake() {
        instance = this;
    }

    public Progressbar healthProgressbar;

    private void Start() {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        HealthManager hm = player.GetComponent<HealthManager>();
        SetHealth(hm.currentHealth, hm.maxHealth);
    }

    public void SetHealth(float currentHealth, float maxHealth) {
        healthProgressbar.SetProgress(currentHealth, maxHealth);
    }
}
