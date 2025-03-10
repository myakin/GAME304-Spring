using UnityEngine;

public class Collectible : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.tag=="Player") {
            // activate a collect ui
            Debug.Log("Press E to collect item");
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.tag=="Player" && other.GetComponent<InputManager>().interactionKey) {
            Debug.Log("Collecting...");
            if (GetComponent<InventoryItemData>()) {
                other.GetComponent<InventoryManager>().AddToInventory(gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag=="Player") {
            // deactivate a collect ui
            Debug.Log("Left interactiono area");
        }
        
    }
}
