using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    //public float timeInvincible = 2.0f; // ���G����
    //private bool isInvincible; // ���G��Ԃ�
    //private float invincibleTimer; // �c�薳�G����

    public int maxHealth = 10; // �ő� HP
    private int currentHealth; // ���݂� HP
    //public float speed = 1.0f;

    public Vector2 speed = new Vector2(0.0f, 0.0f);


    private Rigidbody2D rigidbody2d;
    private float horizontal;
    private float vertical;
    // Update()���Ă΂��O�Ɉ�x�����Ă΂��֐�
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();

        // �Q�[���J�n���� HP ������������
        currentHealth = maxHealth;

        //currentHealth = 1;
    }

    // ���N��Ԃ�ύX����
    public void ChangeHealth(int amount)
    {
        //if (amount < 0)
        //{
        //    if (isInvincible) return;
        //    isInvincible = true;
        //    invincibleTimer = timeInvincible;
        //}

        // ���݂� HP �� 0�`maxHealth �̊ԂɎ��܂�悤�ɕύX����
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }

    // ���t���[���Ă΂��֐�
    void Update()
    {
        // FixedUpdate()�ł� Input �֘A�̓��͂�ǂݎ��̂�
        // �֎~�̂��߁AUpdate()�œ��͒l��ۑ����Ă���
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        speed.x = 15.0f * horizontal * Time.deltaTime;
        speed.y = 15.0f * vertical * Time.deltaTime;

        // ���G���Ԃ̍X�V����
        //if (isInvincible)
        //{
        //    invincibleTimer -= Time.deltaTime;
        //    if (invincibleTimer < 0)
        //    {
        //        isInvincible = false;
        //    }
        //}

    }

    // ��莞�Ԗ��ɌĂ΂��֐�
    void FixedUpdate()
    {

        Vector2 position = transform.position;
        //Vector2 position = rigidbody2d.AddForce(speed);
        rigidbody2d.AddForce(speed);
        

        position.x = position.x + speed.x;
        position.y = position.y + speed.y;


        // �����V�X�e���Ɉʒu��`����
        rigidbody2d.MovePosition(position);
    }

    private Vector2 Vector2(object p, float v)
    {
        throw new NotImplementedException();
    }
}
