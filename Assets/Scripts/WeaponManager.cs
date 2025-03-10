using UnityEngine;

public class WeaponManager : MonoBehaviour
{ 
    public Transform weapon;  
    public bool useRifle;

    private InputManager inputManager;
    private WeaponController weaponController;

    private void Start() {
        inputManager = GetComponent<InputManager>();
        weaponController = weapon.GetComponent<WeaponController>();

    }

    private void Update() {
        if (inputManager.fireKey) {
            weaponController.Fire();
        }
    }

    public void ToggleRifleUsage() {
        useRifle = !useRifle;
    }

    public void UpdateRifleOnHandStatus() {
        Transform targetParent = null;
        if (useRifle) {
            targetParent = SearchInChildren("RifleOnHandPos");
        } else {
            targetParent = SearchInChildren("RifleRestingPos");
        }
        weapon.SetParent(targetParent);
        weapon.localPosition = Vector3.zero;
        weapon.localRotation = Quaternion.identity;
    }

    private Transform SearchInChildren(string searchPattern) {
        Transform[] children = GetComponentsInChildren<Transform>();
        for (int i=0; i<children.Length; i++) {
            Transform child = children[i];
            if (child.name.Contains(searchPattern)) {
                return child;
            }
        }
        return null;
    }
}
