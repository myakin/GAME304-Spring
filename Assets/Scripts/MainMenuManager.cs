using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    public Button[] buttons;
    public GameObject optionsPanel;

    private void Start() {
        buttons[0].onClick.AddListener(NewGame);
        buttons[1].onClick.AddListener(LoadGame);
        buttons[2].onClick.AddListener(SaveGame);
        buttons[3].onClick.AddListener(Options);
        buttons[4].onClick.AddListener(Quit);
    }


    private void NewGame() {
        SceneLoader.instance.LoadScene("GameScene");
    }

    private void LoadGame() {
        
    }

    private void SaveGame() {

    }

    private void Options() {
        optionsPanel.SetActive(true);
    }

    private void Quit() {
        StopAllCoroutines();
        Application.Quit();
    }
}
