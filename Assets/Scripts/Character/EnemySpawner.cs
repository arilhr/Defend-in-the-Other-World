using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    [SerializeField]
    private int totalEnemyInSpawn;
    public LevelManager lvlManager;
    public float minWaitTime, maxWaitTime;

    void Start() {
        StartCoroutine(EnemySpawn(minWaitTime, maxWaitTime));
    }

    IEnumerator EnemySpawn(float minWaitTime, float maxWaitTime) {
        while (totalEnemyInSpawn > 0) {
            float waitTime = Random.Range(minWaitTime, maxWaitTime);
        
            yield return new WaitForSeconds(waitTime);

            totalEnemyInSpawn--;
            Instantiate(enemy, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        }
    }
}
