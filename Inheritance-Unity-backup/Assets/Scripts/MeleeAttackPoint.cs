using UnityEngine;
using System.Collections;

public class MeleeAttackPoint : MonoBehaviour
{

    int damage;

    void OnTriggerEnter2D(Collider2D other)
    {

        print("hit " + other.gameObject.name);


        if (other.tag == "enemy")
        {
            Enemy e = other.gameObject.GetComponent<Enemy>();

            if (!e.IsUnderAttact())
                e.gameObject.GetComponent<Enemy>().UnderAttack(damage);
        }

    }


    public void SetDamage(int d)
    {
        damage = d;
    }

}
