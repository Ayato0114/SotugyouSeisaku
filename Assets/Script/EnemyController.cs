using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update

    public bool vertical;//�c�����Ɉړ����邩

    public float speed = 3.0f;//�ړ����x

    public float changeTime = 3.0f;//�ړ�������؂�ւ���܂ł̎���


    public float span = 2.0f;

    private float timer;
    private float timer_2;
    private int direction = 1;//1�Ȃ�O�����A-1�Ȃ�����

    private Rigidbody2D rigidbody2d;

    private Animator animator;


    private bool isInvincible; //���G��Ԃ�
    private float invincibleTimer; //�c�薳�G����

    public float timeInvincible = 2.0f; //���G����
    [SerializeField] public int maxHealth;   //�ő�HP
    private int currentHealth;

    public UnityEvent OnDestroyed = new UnityEvent();

    private GameObject enemy;

    private GameObject player;

    [SerializeField] public GameObject enemyProjectilePrefab;
    [SerializeField] public GameObject enemyProjectilePrefab_kinsetu;


    //[SerializeField]  float attackDistance = 2;


    //[SerializeField] float chaseDistance = 5;

    //[SerializeField] Transform target = null;   

    //Transform defaultTarget;

    //bool isAttacking = false;

    private Vector2 lookDirection = new Vector2(1, 0);
    private Vector2 lookDirection2 = new Vector2(0, 1);

    [SerializeField] public float length=4.0f;
    private float timeflag = 0.0f;


    public int health
    {
        get { return currentHealth; }
    }

    void Start()
    {



        player = GameObject.FindWithTag("Player");
        enemy = GameObject.FindWithTag("Enemy"); 
        rigidbody2d = GetComponent<Rigidbody2D>();
        timer = changeTime;
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
    }


    // Update is called once per frame
    void Update()
    {

        //���Ԋu�ňړ��������t�����ɂ���
        timer -= Time.deltaTime;
        timer_2 += Time.deltaTime;
        if (timer < 0)
            if (timer < 0)
            {

                lookDirection = -lookDirection;
                lookDirection2 = -lookDirection2;
                direction = -direction;
                timer = changeTime;
            }



       float v= Mathf.Sqrt(((player.transform.position.x - enemy.transform.position.x) * (player.transform.position.x - enemy.transform.position.x)) + ((player.transform.position.y - enemy.transform.position.y) * (player.transform.position.y - enemy.transform.position.y)));





        if (timer_2 > span)
        {
            timer_2 = 0;
            timeflag = 0;
            Lanch();
        }


            if (v <length)
        {
            

            if(timeflag==0)
            {
                timeflag = 1;
                Attack2();

            }
               
            
        }
    }

    void FixedUpdate()
    {
        Vector2 position = transform.position;

        //float diff = (player.transform.position - enemy.transform.position).sqrMagnitude;
        //// �������r�B��r�Ώۂ���悷��̂�Y�ꂸ��
        //if (diff < attackDistance * attackDistance)
        //{
        //    if (!isAttacking)
        //    {
        //        StartCoroutine(nameof(Attack));
        //    }
        //}
        //else if (diff < chaseDistance * chaseDistance)
        //{
        //    target = player.transform;
        //}
        //else
        //{
        //    target = defaultTarget;
        //}


        ////�v���C���[-�G�L�����̈ʒu�֌W����������擾���A���x����艻
        //Vector2 targeting = (target.transform.position - transform.position).normalized;
        //if (targeting.x > 0)
        //{
        //    this.GetComponent<SpriteRenderer>().flipX = true;
        //}
        //else
        //{
        //    this.GetComponent<SpriteRenderer>().flipX = false;
        //}
        ////x�����ɂ̂݃v���C���[��ǂ�
        //this.GetComponent<Rigidbody2D>().velocity = new Vector2((targeting.x * 5), 0);

        
        if (vertical)
        {



            //�c�����̈ړ�����
            position.y = position.y + speed * Time.deltaTime * direction;
            //�A�j���[�^�[�Ƀp�����[�^�𑗐M
            animator.SetFloat("MoveX", 0);
            animator.SetFloat("MoveY", direction);
        }
        else
        {
            //�������̈ړ�����
            position.x = position.x + speed * Time.deltaTime * direction;
            //�A�j���[�^�[�Ƀp�����[�^�𑗐M
            animator.SetFloat("MoveX", direction);
            animator.SetFloat("MoveY", 0);
        }

        //�����V�X�e���Ɉʒu��`����
        rigidbody2d.MovePosition(position);

    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible) return;
            isInvincible = true;
            invincibleTimer = timeInvincible;
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }


    void Lanch()
    {

        //�v���n�u����I�u�W�F�N�g�𐶐�
        GameObject projectileObject = Instantiate
            (enemyProjectilePrefab,
            rigidbody2d.position + Vector2.up * 0.5f,
            Quaternion.identity);
        //Projectile�R���|�[�l���g�ɔ��˖���
        EnemyLunch tama = projectileObject.GetComponent<EnemyLunch>();
        tama.Lanch(lookDirection, 300);


    }

    void Attack2()
    {
        if (vertical)
        {



            //�v���n�u����I�u�W�F�N�g�𐶐�
            GameObject projectileObject = Instantiate
           (enemyProjectilePrefab_kinsetu,
           rigidbody2d.position + Vector2.up * 0.5f,
           Quaternion.identity);
            //Projectile�R���|�[�l���g�ɔ��˖���
            EnemyAttack enemy_attack = projectileObject.GetComponent<EnemyAttack>();
            enemy_attack.Attack2(lookDirection2, 1000);
        }
        else
        {
            //�v���n�u����I�u�W�F�N�g�𐶐�
            GameObject projectileObject = Instantiate
           (enemyProjectilePrefab_kinsetu,
           rigidbody2d.position + Vector2.up * 0.5f,
           Quaternion.identity);
            //Projectile�R���|�[�l���g�ɔ��˖���
            EnemyAttack enemy_attack = projectileObject.GetComponent<EnemyAttack>();
            enemy_attack.Attack2(lookDirection, 1000);
        }



    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Controller player = collision.gameObject.GetComponent<Controller>();
        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }

    private void OnDestroy()
    {
        Debug.Log("Destroyed");
        OnDestroyed.Invoke();
    }

    
}



    
