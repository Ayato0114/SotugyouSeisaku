using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    
    private Rigidbody2D rigidbody2d;

    private GameObject playerObject;
    private Vector3 playerTrans ; //’Ç‚¢‚©‚¯‚é‘ÎÛ‚ÌTransform
    [SerializeField] private float bulletSpeed;  @ //’e‚Ì‘¬“x
    [SerializeField] private float limitSpeed;      //’e‚Ì§ŒÀ‘¬“x
    private Transform bulletTrans;                  //’e‚ÌTransform


    [SerializeField] public float deleteTime;//’e‚ÌŠÔ
    float time = 0f;

    void Awake()
    {
       
       
        rigidbody2d = GetComponent<Rigidbody2D>();
        bulletTrans = GetComponent<Transform>();
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {

        playerObject = GameObject.FindWithTag("Enemy");
        if (playerObject == null)
        {
            playerTrans.x = 1;
            playerTrans.y = 1;
            playerTrans.z = 1;
        }
        else
        {
            playerTrans = playerObject.transform.position;
        }

        time += Time.deltaTime;
        print(time);
        if (time > deleteTime)
        {
            Destroy(gameObject);
        }

        if (transform.position.magnitude > 100.0f)
        {
            Destroy(gameObject);
        }

        if (playerObject == null)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {

        if (playerObject == null)
        {
            Destroy(gameObject);
        }


        if (playerObject != null)
        {

            Vector3 vector3 = playerTrans - bulletTrans.position;         //’e‚©‚ç’Ç‚¢‚©‚¯‚é‘ÎÛ‚Ö‚Ì•ûŒü‚ğŒvZ
            rigidbody2d.AddForce(vector3.normalized * bulletSpeed);                 //•ûŒü‚Ì’·‚³‚ğ1‚É³‹K‰»A”CˆÓ‚Ì—Í‚ğAddForce‚Å‰Á‚¦‚é

            float speedXTemp = Mathf.Clamp(rigidbody2d.velocity.x, -limitSpeed, limitSpeed); //X•ûŒü‚Ì‘¬“x‚ğ§ŒÀ
            float speedYTemp = Mathf.Clamp(rigidbody2d.velocity.y, -limitSpeed, limitSpeed);  //Y•ûŒü‚Ì‘¬“x‚ğ§ŒÀ
            rigidbody2d.velocity = new Vector3(speedXTemp, speedYTemp);           //ÀÛ‚É§ŒÀ‚µ‚½’l‚ğ‘ã“ü

        }
    
       
    }

    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //EnemyController enemy = collision.collider.GetComponent<EnemyController>();
        //if (enemy != null)
        //{
        //    enemy.Fix();
        //}


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

