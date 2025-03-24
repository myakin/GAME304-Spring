using UnityEngine;
using UnityEngine.UI;

public class Progressbar : MonoBehaviour {
    public Image progressbar;

    public void SetProgress(float rate) {
        progressbar.fillAmount = rate;
    }
}
