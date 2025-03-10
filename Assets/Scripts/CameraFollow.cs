using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Transform lookTarget;
    public float upOffset, backOffset, rightOffset, dampening;
    private Vector3 vel, oldPos, targetPos;
    private InputManager inputManager;
    private float totalRotationX, totalRotationY;
    

    private void Start() {
        inputManager = target.GetComponent<InputManager>();
    }


    private void LateUpdate() {
        targetPos = target.position + (Quaternion.AngleAxis(totalRotationY, lookTarget.up) * (-target.forward * backOffset + target.right * rightOffset + target.up * upOffset));
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref vel, dampening);
        // transform.LookAt(lookTarget);
        oldPos = targetPos;

        // transform.rotation *= Quaternion.Euler(inputManager.mouseY, 0 , 0);
        Vector3 lookDirection = lookTarget.position - transform.position;
        totalRotationX += inputManager.mouseY;
        if (inputManager.hor==0 && inputManager.ver==0) {
            totalRotationY += inputManager.mouseX * 10;
        } else {
            if (totalRotationY>0) {
                totalRotationY -= 1;
                if (totalRotationY<0) {
                    totalRotationY = 0;
                }
            }
        }
        transform.rotation = Quaternion.LookRotation(lookDirection, lookTarget.up) * Quaternion.Euler(-totalRotationX, 0 , 0);
        
    }

    public void ResetCamAccumValues() {
        totalRotationY = 0;
    }
}
