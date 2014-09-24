using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;

    public Weapon weapon;

    public GameObject up_meleeAttackPoint;
    public GameObject down_meleeAttackPoint;
    public GameObject left_meleeAttackPoint;
    public GameObject right_meleeAttackPoint;

    float hori_move, vert_move;
    Vector2 movement;
    Rigidbody2D player_body;
    Animator anim;
    GameManager gm;

    bool isAttacking = false;


    void Start()
    {
        player_body = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        // movement 
        hori_move = Input.GetAxisRaw("Horizontal");
        vert_move = Input.GetAxisRaw("Vertical");

        // move if not attacking
        if (!isAttacking)
            Move(hori_move, vert_move);

        // anim trigger 
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
            ChangeMoveAnim(hori_move, vert_move);

        // anim reset to idle
        else if (Input.GetButtonUp("Horizontal") || Input.GetButtonUp("Vertical"))
            anim.SetBool("running", false);

        // melee attack
        if (Input.GetButtonDown("Fire1") && !isAttacking)
            MeleeAttack();
    }

    void MeleeAttack()
    {
        player_body.velocity = Vector2.zero;

        isAttacking = true;
        anim.SetBool("attack", true);
    }

    void Move(float hori_move, float vert_move)
    {
        movement.Set(hori_move, vert_move);
        player_body.velocity = movement.normalized * moveSpeed;
    }


    void ChangeMoveAnim(float x, float y)
    {
        // running
        anim.SetBool("running", true);

        if (x < 0)
            anim.SetInteger("dir", 1);

        else if (x > 0)
            anim.SetInteger("dir", 3);

        else if (y < 0)
            anim.SetInteger("dir", 4);

        else if (y > 0)
            anim.SetInteger("dir", 2);
    }

    // ==== animation access funcions ==== //

    void AttackFinished()
    {
        // deactive attack point
        up_meleeAttackPoint.SetActive(false);
        down_meleeAttackPoint.SetActive(false);
        left_meleeAttackPoint.SetActive(false);
        right_meleeAttackPoint.SetActive(false);

        anim.SetBool("attack", false);
        isAttacking = false;
    }

    void MeleeAttackUp()
    {
        up_meleeAttackPoint.SetActive(true);
        up_meleeAttackPoint.GetComponent<MeleeAttackPoint>().SetDamage(Random.Range(weapon.minDamage, weapon.maxDamage));
    }

    void MeleeAttackDown()
    {
        down_meleeAttackPoint.SetActive(true);
        down_meleeAttackPoint.GetComponent<MeleeAttackPoint>().SetDamage(Random.Range(weapon.minDamage, weapon.maxDamage));
    }

    void MeleeAttackRight()
    {
        right_meleeAttackPoint.SetActive(true);
        right_meleeAttackPoint.GetComponent<MeleeAttackPoint>().SetDamage(Random.Range(weapon.minDamage, weapon.maxDamage));
    }

    void MeleeAttackLeft()
    {
        left_meleeAttackPoint.SetActive(true);
        left_meleeAttackPoint.GetComponent<MeleeAttackPoint>().SetDamage(Random.Range(weapon.minDamage, weapon.maxDamage));
    }

    public void SetGM(GameManager GM)
    {
        this.gm = GM;
    }

}

[System.Serializable]
public class Weapon
{
    public enum WeaponType
    {
        melee,
        range
    }

    public WeaponType weapoonType;

    public int minDamage;
    public int maxDamage;
}
