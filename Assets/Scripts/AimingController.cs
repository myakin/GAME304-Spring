using UnityEngine;

public class AimingController : MonoBehaviour
{
    public bool byPass = true;
    private Transform camTr;

    private void OnEnable() {
        camTr = Camera.main.transform;
    }

    
    void Update()
    {
        if (byPass)
            return;
        transform.position = camTr.position + camTr.forward * 10;
    }
}
