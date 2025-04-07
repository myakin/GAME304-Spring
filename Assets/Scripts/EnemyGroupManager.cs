using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class EnemyGroupManager : MonoBehaviour
{
    public List<Enemy> enemies;

    private IEnumerator Start() {
        for (int i=0; i<enemies.Count;  i++) {
            enemies[i].GetComponent<Animator>().enabled = true;
        }
        yield return new WaitForSeconds(1);
        for (int i=0; i<enemies.Count;  i++) {
            enemies[i].GetComponent<Animator>().enabled = false;
        }
    }

    public void InitializeEnemies() {
        for (int i=0; i<enemies.Count; i++) {
            enemies[i].Initialize();
        }
    }
    public void CompletelyDeactivateEnemies() {
        for (int i=0; i<enemies.Count; i++) {
            enemies[i].CompletelyDeactivate();
        }
    }
}
