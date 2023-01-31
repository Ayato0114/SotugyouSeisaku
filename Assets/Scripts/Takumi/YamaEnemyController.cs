using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YamaEnemyController : MonoBehaviour
{
    // Start is called before the first frame update

    public bool vertical;//�c�����Ɉړ����邩

    public float speed = 3.0f;//�ړ����x

    public float changeTime = 3.0f;//�ړ�������؂�ւ���܂ł̎���

    private float timer;
    private int direction = 1;//1�Ȃ�O�����A-1�Ȃ�����

    private Rigidbody2D rigidbody2d;

    private Animator animator;

    // �^�[�����e�X�g�p
    public GameObject target;


    private bool isInvincible; //���G��Ԃ�
    private float invincibleTimer; //�c�薳�G����

    public float timeInvincible = 2.0f; //���G����
    public int maxHealth = 5;   //�ő�HP
    private int currentHealth;

    private bool frg = false;

    public int health
    {
        get { return currentHealth; }
    }

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        timer = changeTime;
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
    }


    // Update is called once per frame
    void Update()
    {
        // �^�[�����e�X�g�p
        
        if (frg)
        {
            //���Ԋu�ňړ��������t�����ɂ���
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                direction = -direction;
                timer = changeTime;
            }
        }

        frg = target.GetComponent<YamaRubyController>().frg;
    }
    void FixedUpdate()
    {
        // �^�[�����e�X�g�p
        if (frg)
        {
            Vector2 position = transform.position;

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
        else
        {
            animator.SetFloat(0, 0);
            animator.SetFloat(0, 0);
        }
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




