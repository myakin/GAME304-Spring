using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Progressbar : MonoBehaviour {
    public Image progressbar;
    public TextMeshProUGUI valueTMP;

    public void SetProgress(float rate) {
        progressbar.fillAmount = rate;
    }

    public void SetProgress(float currentValue, float maxValue) {
        if (!valueTMP.gameObject.activeSelf)
            valueTMP.gameObject.SetActive(true);
        progressbar.fillAmount = currentValue / maxValue;
        valueTMP.text = "<mspace=0.5em>" + currentValue.ToString("F0") + " / " + maxValue.ToString("F0");
    }

}
