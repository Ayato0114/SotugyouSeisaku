using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    
    private Rigidbody2D rigidbody2d;

    private GameObject enemyObject;
    private Vector3 enemyTrans ; //�ǂ�������Ώۂ�Transform
    [SerializeField] private float bulletSpeed;  �@ //�e�̑��x
    [SerializeField] private float limitSpeed;      //�e�̐������x
    private Transform bulletTrans;                  //�e��Transform


    [SerializeField] public float deleteTime;//�e�̎���
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

        enemyObject = GameObject.FindWithTag("Enemy");
        if (enemyObject == null)
        {
            enemyTrans.x = 0;
            enemyTrans.y = 0;
            enemyTrans.z = 0;
        }
        else
        {
            enemyTrans = enemyObject.transform.position;
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

        if (enemyObject == null)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {

        if (enemyObject == null)
        {
            Destroy(gameObject);
        }


        if (enemyObject != null)
        {

            Vector3 vector3 = enemyTrans - bulletTrans.position;         //�e����ǂ�������Ώۂւ̕������v�Z
            //����Ȃ���������Ȃ��i�x�N�g�������ɂ����Ɛi�܂��āA�x�N�g���̌�������]�A�X�V�����ق������������j
            rigidbody2d.AddForce(vector3.normalized * bulletSpeed);     //�����̒�����1�ɐ��K���A�C�ӂ̗͂�AddForce�ŉ�����
            float speedXTemp = Mathf.Clamp(rigidbody2d.velocity.x, -limitSpeed, limitSpeed); //X�����̑��x�𐧌�
            float speedYTemp = Mathf.Clamp(rigidbody2d.velocity.y, -limitSpeed, limitSpeed);  //Y�����̑��x�𐧌�
            rigidbody2d.velocity = new Vector3(speedXTemp, speedYTemp);           //���ۂɐ��������l����

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

