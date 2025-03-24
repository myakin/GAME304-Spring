using UnityEngine;
using UnityEngine.Animations.Rigging;
using System.Collections;

public class WeaponManager : MonoBehaviour
{ 
    public Transform weapon;
    public Rig rig;
    public FollowObject leftHandFollowScript;
    public FollowObject aimTargetFollowScript;
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
        if (useRifle) {
            SceneLoader.instance.LoadScene("CombatUI", true);
            GetComponentInChildren<AimingController>().byPass = false;
        } else {
            SceneLoader.instance.UnloadScene("CombatUI");
            GetComponentInChildren<AimingController>().byPass = true;
        }
        
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

    public void SetAnimationRigging() {
        Debug.Log(useRifle);
        StartCoroutine(SetWeight(useRifle ? 1 : 0));
    }

    private IEnumerator SetWeight(float value) {
        float initialValue = rig.weight;
        float timer = 0;
        float duration = 1;
        while (timer<duration) {
            rig.weight = Mathf.Lerp(initialValue, value, timer/duration);
            timer+=Time.deltaTime;
            yield return null;
        }
        rig.weight = value;
        leftHandFollowScript.byPass = value == 0;
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
