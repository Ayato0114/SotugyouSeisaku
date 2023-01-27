using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private GameObject playerObject;
    private Rigidbody2D rigidbody2d;

    private float titen_x;
    private float titen_y;
    private float titen_z;
    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        playerObject = GameObject.FindWithTag("Player");

        if (gameObject == true)
        {

            titen_x = playerObject.transform.position.x;
            titen_y = playerObject.transform.position.y;
            titen_z = playerObject.transform.position.z;

            if (transform.position.x-titen_x > 1.0f)
            {
                Destroy(gameObject);
                
            }
            if (transform.position.y -titen_y > 1.0f)
            {
                Destroy(gameObject);
            }

            if (transform.position.x - titen_x < -1.0f)
            {
                Destroy(gameObject);

            }
            if (transform.position.y - titen_y < -1.0f)
            {
                Destroy(gameObject);
            }
        }
        
    }

    public void Attacks(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        EnemyController enemies = collision.gameObject.GetComponent<EnemyController>();
        if (enemies != null)
        { 
            enemies.ChangeHealth(-1);

            if (enemies.health == 0)
            {
                Destroy(enemies.gameObject);
            }
        }
        

        Destroy(gameObject);
    }
}
