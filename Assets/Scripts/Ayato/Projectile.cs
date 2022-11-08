using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rigidbody2d;
    [SerializeField] private Transform playerTrans; //追いかける対象のTransform
    [SerializeField] private float bulletSpeed;  　 //弾の速度
    [SerializeField] private float limitSpeed;      //弾の制限速度
    private Transform bulletTrans;                  //弾のTransform

    [SerializeField] public float deleteTime;//弾の時間
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
    }
    private void FixedUpdate()
    {
         Vector3 vector3 = playerTrans.position - bulletTrans.position;         //弾から追いかける対象への方向を計算
        rigidbody2d.AddForce(vector3.normalized * bulletSpeed);                 //方向の長さを1に正規化、任意の力をAddForceで加える

        float speedXTemp = Mathf.Clamp(rigidbody2d.velocity.x, -limitSpeed, limitSpeed);　//X方向の速度を制限
        float speedYTemp = Mathf.Clamp(rigidbody2d.velocity.y, -limitSpeed, limitSpeed);  //Y方向の速度を制限
        rigidbody2d.velocity = new Vector3(speedXTemp, speedYTemp);　　　　　　　　　　　//実際に制限した値を代入
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

