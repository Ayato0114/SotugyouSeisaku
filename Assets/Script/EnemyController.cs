using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update

    public bool vertical;//�c�����Ɉړ����邩

    public float speed = 3.0f;//�ړ����x

    public float changeTime = 3.0f;//�ړ�������؂�ւ���܂ł̎���

    private float timer;
    private int direction = 1;//1�Ȃ�O�����A-1�Ȃ�����

    private Rigidbody2D rigidbody2d;

    private Animator animator;


    private bool isInvincible; //���G��Ԃ�
    private float invincibleTimer; //�c�薳�G����

    public float timeInvincible = 2.0f; //���G����
    [SerializeField]  public int maxHealth ;   //�ő�HP
    private int currentHealth;



    private GameObject enemy;

    private GameObject target;


   


    public int health
    {
        get { return currentHealth; }
    }

    void Start()
    {
      


        target = GameObject.Find("Player");
        enemy = GameObject.Find("Enemy");
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
        if (timer < 0)
            if (timer < 0)
            {
                direction = -direction;
                timer = changeTime;
            }

    }

    void FixedUpdate()
    {
        Vector2 position = transform.position;

       

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
}



    
