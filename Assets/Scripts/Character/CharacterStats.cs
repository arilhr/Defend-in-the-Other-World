using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    // Stats
    [SerializeField]
    protected int maxHP;
    [SerializeField]
    protected int maxMP;
    [SerializeField]
    protected int hp;
    [SerializeField]
    protected int mp;
    [SerializeField]
    protected int damage;
    [SerializeField]
    protected float moveSpeed;
    protected Animator anim;
    
    void Start() {
        hp = maxHP;
        mp = maxMP;
    }

    public void TakeDamage(int damageAmount) {
        hp -= damageAmount;
    }

    public int GetDamage() {
        return damage;
    }

    public int GetHP() {
        return hp;
    }

    public int GetMP() {
        return mp;
    }
}
