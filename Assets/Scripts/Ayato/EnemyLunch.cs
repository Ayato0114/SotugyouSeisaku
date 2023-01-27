using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLunch : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody2D rigidbody2d;

    private GameObject playerObject;
    private Vector3 playerTrans; //�ǂ�������Ώۂ�Transform
    [SerializeField] private float bulletSpeed_enemy;  �@ //�e�̑��x
    [SerializeField] private float limitSpeed_enemy;      //�e�̐������x
    private Transform bullet_enemyTrans;                  //�e��Transform


    [SerializeField] public float deleteTime2;//�e�̎���
    float time = 0f;

    void Awake()
    {


        rigidbody2d = GetComponent<Rigidbody2D>();
        bullet_enemyTrans = GetComponent<Transform>();
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {

        playerObject = GameObject.FindWithTag("Player");
        if (playerObject == null)
        {
            playerTrans.x = 0;
            playerTrans.y = 0;
            playerTrans.z = 0;
        }
        else
        {
            playerTrans = playerObject.transform.position;
        }

        time += Time.deltaTime;
        print(time);

        if (time > deleteTime2)
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

            Vector3 vector3 = playerTrans - bullet_enemyTrans.position;         //�e����ǂ�������Ώۂւ̕������v�Z
            //����Ȃ���������Ȃ��i�x�N�g�������ɂ����Ɛi�܂��āA�x�N�g���̌�������]�A�X�V�����ق������������j
            rigidbody2d.AddForce(vector3.normalized * bulletSpeed_enemy);     //�����̒�����1�ɐ��K���A�C�ӂ̗͂�AddForce�ŉ�����
            float speedXTemp = Mathf.Clamp(rigidbody2d.velocity.x, -limitSpeed_enemy, limitSpeed_enemy); //X�����̑��x�𐧌�
            float speedYTemp = Mathf.Clamp(rigidbody2d.velocity.y, -limitSpeed_enemy, limitSpeed_enemy);  //Y�����̑��x�𐧌�
            rigidbody2d.velocity = new Vector3(speedXTemp, speedYTemp);           //���ۂɐ��������l����

        }


    }

    public void Lanch(Vector2 direction, float force)
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

