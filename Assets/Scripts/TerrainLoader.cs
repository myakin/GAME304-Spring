using UnityEngine;
using UnityEngine.SceneManagement;

public class TerrainLoader : MonoBehaviour
{
    public string sceneNameToLoad;
    public GameObject terrainToLoad;

    private void OnTriggerEnter(Collider other) {
        if (other.tag=="Player") {
            Vector3 enterPoint = other.transform.position;
            if (IsInSameDirection(enterPoint)) {
                // terrainToLoad.SetActive(true);
                // SceneManager.LoadScene(sceneNameToLoad, LoadSceneMode.Additive);
                SceneLoader.instance.LoadScene(sceneNameToLoad, true);
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag=="Player") {
            Vector3 exitPoint = other.transform.position;
            if (IsInSameDirection(exitPoint)) {
                // terrainToLoad.SetActive(false);
                // SceneManager.UnloadSceneAsync(sceneNameToLoad);
                SceneLoader.instance.UnloadScene(sceneNameToLoad);
            }
        }
    }

    private bool IsInSameDirection(Vector3 pos) {
        Vector3 operationVector = pos - transform.position;
        return Vector3.Angle(operationVector, transform.forward) < 90;
    }

}
