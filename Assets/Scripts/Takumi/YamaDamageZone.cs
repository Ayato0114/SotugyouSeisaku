using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YamaDamageZone : MonoBehaviour
{
    public int damageAmount = 1;        // �_���[�W�� 
    public float timeInvincible = 2.0f; // �N�[���^�C��
    private bool isInvincible;          // �N�[���^�C����
    private float invincibleTimer;      // �c�莞��

    void Update()
    {
        // �N�[���^�C���̍X�V����
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
            {
                isInvincible = false;
            }
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // �Փ˂������肪 Ruby �����肷��
        YamaRubyController controller = collision.GetComponent<YamaRubyController>();
        if (controller != null)
        {
            if (isInvincible) return;
            isInvincible = true;
            invincibleTimer = timeInvincible;

            Damage(controller);
        }

    }

    public void Damage(YamaRubyController controller)
    {
        // Ruby �� HP �� ���炷
        controller.ChangeHealth(-damageAmount);
    }



    // �g���K�[�ݒ�� 2D �R���C�_�[�ɏՓ˂������ɌĂ΂��֐�

}
