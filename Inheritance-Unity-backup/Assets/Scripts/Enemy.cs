using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public int hp = 100;
    public int attackPower = 1;

    Animator anim;
    bool isUnderAttack = false;
    GameManager gm;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    public void UnderAttack(int damage)
    {
        isUnderAttack = true;

        anim.SetBool("underAttack", true);

        hp -= damage;

        if (hp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    void UnderAttackFinish()
    {
        anim.SetBool("underAttack", false);
        isUnderAttack = false;
    }


    // ======= public access ======= //

    public bool IsUnderAttact()
    {
        return isUnderAttack;
    }

    public int GetHP()
    {
        return hp;
    }

    public int GetAttackPower()
    {
        return attackPower;
    }

    public void SetGM(GameManager GM)
    {
        this.gm = GM;
    }
}


