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
    public float speed = 1.0f;

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
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;
        // �����V�X�e���Ɉʒu��`����
        rigidbody2d.MovePosition(position);
    }

    
}
