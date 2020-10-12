using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFunction : CharacterStats
{
    protected CharacterController controller;
    [SerializeField]
    protected Transform cam;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    void Awake() {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    protected void Lose() {
        if (hp <= 0) {
            Debug.Log("Wi Los");
        }
    }

    public void PlayerMovement() {
        // ambil input direction dari player
        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;

        if (direction.magnitude >= 0.1f) {
            // mengambil nilai arah pandang camera player
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            // rotasi badan player
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            // sesuaikan arah jalan player dengan pandangan kamera player
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            
            // Jalankan player
            controller.Move(moveDir * moveSpeed * Time.deltaTime);
        }
    }

    protected void BasicAttack() {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            anim.SetTrigger("Attack");
    }
}