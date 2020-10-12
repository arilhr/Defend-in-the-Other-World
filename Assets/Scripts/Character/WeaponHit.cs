using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHit : MonoBehaviour
{
    private GameObject attacker;
    private bool attackCount = true;
    [SerializeField]
    private List<string> targetTag = new List<string>();

    void Start() {
        attacker = transform.parent.parent.parent.gameObject;
    }

    int AttackerDamage() {
        if (attacker.CompareTag("Player"))
            return attacker.GetComponent<PlayerController>().GetDamage();
        else if (attacker.CompareTag("Enemy"))
            return attacker.GetComponent<EnemyController>().GetDamage();
        else
            return 0;
    }

    void OnTriggerStay(Collider other) {
        Debug.Log(other.tag);
        if (targetTag.Contains(other.tag) && attackCount && attacker.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Attack")) {
            if (other.gameObject.GetComponent<PlayerController>() != null)
                other.gameObject.GetComponent<PlayerController>().TakeDamage(AttackerDamage());
            else if (other.gameObject.GetComponent<EnemyController>() != null)
                other.gameObject.GetComponent<EnemyController>().TakeDamage(AttackerDamage());
            else if (other.gameObject.GetComponent<Tower>() != null)
                other.gameObject.GetComponent<Tower>().TakeDamage(AttackerDamage());
            StartCoroutine(attackSpeed(attacker.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length));
        }
    }


    IEnumerator attackSpeed(float waitTime) {
        attackCount = false;
        yield return new WaitForSeconds(waitTime);
        attackCount = true;
    }
}
