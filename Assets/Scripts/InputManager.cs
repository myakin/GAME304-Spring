using UnityEngine;

public class InputManager : MonoBehaviour
{
    public float hor, ver, jump, shift, mouseX, mouseY;
    public bool inventoryKey, interactionKey, takeOrPutWeaponKey, fireKey;

    private void Update() {
        inventoryKey = Input.GetKeyDown(KeyCode.I);
        interactionKey = Input.GetKeyDown(KeyCode.E);
        takeOrPutWeaponKey = Input.GetKeyDown(KeyCode.Alpha1);
        fireKey = Input.GetMouseButton(0);

        if (InventoryUIManager.instance) {
            return;
        }

        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");
        shift = Input.GetAxis("Fire3");
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        
    }
}
