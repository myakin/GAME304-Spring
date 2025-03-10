using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader instance;

    private void Awake() {
        if (instance==null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else if (instance!=this) {
            Destroy(gameObject);
        }
    }   


    public void LoadScene(string sceneName, bool additive = false) {
        SceneManager.LoadScene(sceneName, additive ? LoadSceneMode.Additive : LoadSceneMode.Single);
    }

    public void UnloadScene(string sceneName) {
        SceneManager.UnloadSceneAsync(sceneName);
    }


}
