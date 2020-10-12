using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PlayerFunction
{
    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        hp = maxHP;
        mp = maxMP;
    }

    void Update() {
        PlayerMovement();

        // Basic Attack
        if (Input.GetMouseButtonDown(0)) {
            BasicAttack();
        }

        // Lose
        Lose();
    }
}
