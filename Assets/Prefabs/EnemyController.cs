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
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        timer = changeTime;
        animator = GetComponent<Animator>();
    }
       
    
    // Update is called once per frame
     void Update()
    {
        //���Ԋu�ňړ��������t�����ɂ���
        timer -= Time.deltaTime;
        if(timer<0)
        {
            direction = -direction;
            timer = changeTime;
        }
    }
    void FixedUpdate()
    {
        Vector2 position = transform.position;

        if(vertical)
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
}



    