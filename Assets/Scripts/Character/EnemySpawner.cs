using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    private int enemyCount = 0;
    public float minWaitTime, maxWaitTime;

    void Start() {
        StartCoroutine(EnemySpawn(minWaitTime, maxWaitTime));
    }

    IEnumerator EnemySpawn(float minWaitTime, float maxWaitTime) {
        while (enemyCount < 10) {
            float waitTime = Random.Range(minWaitTime, maxWaitTime);
        
            yield return new WaitForSeconds(waitTime);
            Instantiate(enemy, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            enemyCount++;
        }
        
    }
}
