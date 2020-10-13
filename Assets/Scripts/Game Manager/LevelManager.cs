using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int totalEnemy;

    void LevelCompleted() {
        if (totalEnemy == 0) {
            Debug.Log("Level Selesai");
        }
    }
}
