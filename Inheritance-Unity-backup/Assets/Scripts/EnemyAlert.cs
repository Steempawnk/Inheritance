using UnityEngine;
using System.Collections;

public class EnemyAlert : MonoBehaviour
{
    public GameObject mob;

    public int speed = 2;

    Rigidbody2D mobBody;

    Vector2 movement = new Vector2(0, 0);

    // Use this for initialization
    void Start()
    {
        mobBody = gameObject.GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "player")
        {
            ChasePlayer(other.gameObject);

            print("chasing player");
        }
    }

    void ChasePlayer(GameObject player)
    {
        if (player.transform.position.x < mob.transform.position.x)
        {
            movement.x = -1;
        }
        else if (player.transform.position.x < mob.transform.position.x)
        {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }

        mobBody.velocity = movement * speed;
    }

}
