using UnityEngine;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int minNumberOfSpawns = 3;
    [SerializeField] private int maxNumberOfSpawns = 10;
    [SerializeField] private int maxSpawnDistance = 15;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            SpawnEnemies();
        }
    }


    private void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {
            DespawnEnemies();  
        } 
    }

    private void SpawnEnemies() {
        // prepare the system
        GameObject enemyGroupPrefab = Resources.Load("EnemyGroup") as GameObject;
        GameObject enemyGroupObject = Instantiate(enemyGroupPrefab, transform.position, transform.rotation, transform);
        EnemyGroupManager enemyGroupManager = enemyGroupObject.GetComponent<EnemyGroupManager>();
        enemyGroupManager.enemies = new List<Enemy>();

        // spawn enemies
        int numOfEnemies = Random.Range(minNumberOfSpawns, maxNumberOfSpawns + 1);
        for (int i=0; i<numOfEnemies; i++) {
            Vector3 pos = DefinePosition();
            Quaternion rot = Quaternion.Euler(0, Random.Range(0, 360), 0);
            GameObject enemyPrefab = Resources.Load("Zombie") as GameObject;
            GameObject enemy = Instantiate(enemyPrefab, pos, rot, enemyGroupObject.transform);

            enemyGroupManager.enemies.Add(enemy.GetComponent<Enemy>());
        }
        enemyGroupManager.Initiate();
    }

    private Vector3 DefinePosition() {
        float angle = Random.Range(0, 360);
        float distance = Random.Range(0, maxSpawnDistance);

        Vector3 returnValue = transform.position + Quaternion.AngleAxis(angle, transform.up) * (Vector3.forward * distance);

        RaycastHit hit;
        if (Physics.Raycast(returnValue + transform.up * 1000, Vector3.down, out hit, 5000, 1<<0, QueryTriggerInteraction.Ignore)) {
            returnValue = hit.point;
        }
        return returnValue;
    }

    private void DespawnEnemies() {
        if (transform.childCount>0) {
            for (int i=transform.childCount-1; i>=0; i--) {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
    }
}
