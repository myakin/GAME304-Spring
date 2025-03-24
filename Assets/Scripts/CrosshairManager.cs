using UnityEngine;
using UnityEngine.UI;

public class CrosshairManager : MonoBehaviour
{
    public static CrosshairManager instance;

    private void Awake() {
        instance = this;
    }


    public Image crosshair;

    
}
