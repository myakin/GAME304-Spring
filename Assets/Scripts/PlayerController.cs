using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float smoothTime = 0.1f;
    private Animator animator;
    private InputManager inputManager;
    private float oldShifValue;
    private float runVel;
    private Transform mainCam;
    private bool useRifle;
    private WeaponManager weaponManager;
    

    private void Start() {
        animator = GetComponent<Animator>();
        inputManager = GetComponent<InputManager>();
        mainCam = Camera.main.transform;
        weaponManager = GetComponent<WeaponManager>();
    }

    private void Update() {
        float shiftValue = inputManager.shift + 1;
        float run = Mathf.SmoothDamp(oldShifValue, shiftValue, ref runVel, smoothTime, 2);
        animator.SetFloat("hor", inputManager.hor * run);
        animator.SetFloat("ver", inputManager.ver * run);
        oldShifValue = run;

        if (inputManager.takeOrPutWeaponKey) {
            ProcessWeaponState();
        }

        if (inputManager.hor!=0 || inputManager.ver!=0) {
            SetPlayerRotationToCamDirection();
            transform.rotation *= Quaternion.Euler(0, inputManager.mouseX, 0);
        }
        
            

        if (inputManager.inventoryKey) {
            if (!InventoryUIManager.instance) {
                SceneLoader.instance.LoadScene("InventoryUI", true);
            } else {
                SceneLoader.instance.UnloadScene("InventoryUI");
            }
        }
    }

    private void SetPlayerRotationToCamDirection() {
        if (Vector3.Angle(transform.forward, mainCam.forward) > 5) {
            Vector3 rightAxis = -Vector3.Cross(mainCam.forward, Vector3.up);
            Vector3 forwarAxis = Vector3.Cross(rightAxis, Vector3.up);
            transform.rotation = Quaternion.LookRotation(forwarAxis, Vector3.up);
            mainCam.GetComponent<CameraFollow>().ResetCamAccumValues();
        }
    }

    private void ProcessWeaponState() {
        // if (useRifle) {
        //     animator.SetBool("useRifle", true);
        // } else {
        //     animator.SetBool("useRifle", false);
        // }
        useRifle = !useRifle;
        animator.SetBool("useRifle", useRifle);
        weaponManager.ToggleRifleUsage();
    }
    
} 
