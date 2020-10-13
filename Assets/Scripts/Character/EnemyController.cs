using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : CharacterStats
{
    [SerializeField]
    protected float attackDistance;
    protected CharacterController enemyController;
    protected Transform target;
    protected NavMeshAgent enemyAgent;
    private LevelManager lvlManager;

    void Awake() {
        enemyController = GetComponent<CharacterController>();
        enemyAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        lvlManager = GameObject.FindWithTag("GameManager").GetComponent<LevelManager>();
    }

    void Update() {
        EnemyMovement();
        EnemyDie();
    }

    void FindATarget() {
        if (Vector3.Distance(PlayerManager.instance.player.transform.position, transform.position) <= Vector3.Distance(PlayerManager.instance.tower.transform.position, transform.position)) {
            target = PlayerManager.instance.player.transform;
        } else {
            target = PlayerManager.instance.tower.transform;
        }
    }

    void EnemyMovement() {
        FindATarget();
        if (Vector3.Distance(target.position, transform.position) > attackDistance) {
            enemyAgent.SetDestination(target.position);
        } else {
            enemyAgent.velocity = Vector3.zero;
            EnemyRotationToTarget();
            EnemyAttack();
        }
    }

    void EnemyRotationToTarget() {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void EnemyAttack() {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            anim.SetTrigger("Attack");
    }

    void EnemyDie() {
        if (hp <= 0) {
            lvlManager.totalEnemy--;
            Destroy(gameObject);
        }
    }
}
