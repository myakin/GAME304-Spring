using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionsPanelManager : MonoBehaviour
{
    public Button closeButton;

    private void Start() {
        closeButton.onClick.AddListener(Close);
    }

    public void Close() {
        gameObject.SetActive(false);
    }
}
