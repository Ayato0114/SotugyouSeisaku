using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;
    private float horizontal;
    private float vertical;
    public float speed = 3.0f;//�ړ����x
    private Animator animator;
    private Vector2 lookDirection = new Vector2(1, 0);

    private bool isInvincible; //���G��Ԃ�
    private float invincibleTimer; //�c�薳�G����

    public float timeInvincible = 2.0f; //���G����
    public int maxHealth = 5;   //�ő�HP
    private int currentHealth;

    public GameObject projectilePrefab;
    // Start is called before the first frame update


    public bool isArea;
    public int health
    {
        get { return currentHealth; }
    }

    void Start()
    {
        
        rigidbody2d = GetComponent<Rigidbody2D>();

        //�Q�[���J�n����HP������������
        currentHealth = maxHealth;

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //FixedUpdate()�ł�input�֘A�̓��͂�ǂݎ��̂�
        //�֎~�̂��߁Aupdate()�œ��͒l��ۑ����Ă���
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        //���͒l����
        Vector2 move = new Vector2(horizontal, vertical);
        //move.x�Amove.y�̒l��0.0f�łȂ����͈ړ�������ݒ肷��
        //�����͒l���Ȃ��ꍇ�ł��������Ă������ێ����Ă�����������
        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection = move;
            lookDirection.Normalize();
        }
        //Animator�փp�����[�^�𑗐M
        animator.SetFloat("LookX", lookDirection.x);
        animator.SetFloat("LookY", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        //Debug.Log(horizontal);//�������͒l���R���\�[���E�B���h�E�֏o��
        Vector2 position = transform.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;
        transform.position = position;

        // ���G���ԍX�V����
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
            {
                isInvincible = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Launch();
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            Launch();
        }

    }
    void FixedUpdate()
    {
        Vector2 position = transform.position;

        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        //�����V�X�e���Ɉʒu��`����
        rigidbody2d.MovePosition(position);

    }


    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            animator.SetTrigger("Hit");

            if (isInvincible) return;
            isInvincible = true;
            invincibleTimer = timeInvincible;
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

    //    //EnemyController enemy_controllers = collision.GetComponent<EnemyController>();
    //    //if (enemy_controllers != null)
    //    //{
    //    //    enemy_controllers.ChangeHealth(-1);

    //    //    if (enemy_controllers.health == 0)
    //    //    {
    //    //        Destroy(enemy_controllers.gameObject);
    //    //    }
    //    //}
    }
  

    
    void Launch()
    {

        //�v���n�u����I�u�W�F�N�g�𐶐�
        GameObject projectileObject = Instantiate
            (projectilePrefab,
            rigidbody2d.position + Vector2.up * 0.5f,
            Quaternion.identity);
        //Projectile�R���|�[�l���g�ɔ��˖���
        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(lookDirection, 300);
       
        //Animator�փp�����[�^�l�𑗐M
        animator.SetTrigger("Launch");
    }

    //void Attack()
    //{

    //    //�v���n�u����I�u�W�F�N�g�𐶐�
    //    GameObject projectileObject = Instantiate
    //        (projectilePrefab,
    //        rigidbody2d.position + Vector2.up * 0.5f,
    //        Quaternion.identity);
    //    //Projectile�R���|�[�l���g�ɔ��˖���
    //    Projectile projectile = projectileObject.GetComponent<Projectile>();
    //    projectile.Attack(lookDirection, 300);
    //    //Animator�փp�����[�^�l�𑗐M
    //    animator.SetTrigger("Launch");
    //}

}
