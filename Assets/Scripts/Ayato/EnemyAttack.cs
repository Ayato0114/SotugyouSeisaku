using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private GameObject enemyObject;
    private Rigidbody2D rigidbody2d;

    private float e_titen_x;
    private float e_titen_y;
    private float e_titen_z;
    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        enemyObject = GameObject.FindWithTag("Enemy");

        if (gameObject == true)
        {

            e_titen_x = enemyObject.transform.position.x;
            e_titen_y = enemyObject.transform.position.y;
            e_titen_z = enemyObject.transform.position.z;

            if (transform.position.x - e_titen_x > 2.0f)
            {
                Destroy(gameObject);

            }
            if (transform.position.y - e_titen_y > 2.0f)
            {
                Destroy(gameObject);
            }

            if (transform.position.x - e_titen_x < -2.0f)
            {
                Destroy(gameObject);

            }
            if (transform.position.y - e_titen_y < -2.0f)
            {
                Destroy(gameObject);
            }
        }

    }

    public void Attack2(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Controller players = collision.gameObject.GetComponent<Controller>();
        if (players != null)
        {
            players.ChangeHealth(-1);

            if (players.health == 0)
            {
                Destroy(players.gameObject);
            }
        }

        Destroy(gameObject);
    }
}
