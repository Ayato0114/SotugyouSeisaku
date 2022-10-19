using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    public int damageAmount = 1;    // �_���[�W�� 
    public float timeInvincible = 2.0f; // �N�[���^�C��
    private bool isInvincible; // �N�[���^�C����
    private float invincibleTimer; // �c�莞��

    void Update()
    {
        // ���G���Ԃ̍X�V����
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
        //Debug.Log("�g���K�[�ɐN�����Ă���I�u�W�F�N�g : " + collision);
        // �Փ˂������肪 Ruby �����肷��
        RubyController controller = collision.GetComponent<RubyController>();
        if (controller != null)
        {
            if (isInvincible) return;
            isInvincible = true;
            invincibleTimer = timeInvincible;

            Damage(controller);
        }

    }

    public void Damage(RubyController controller)
    {
        // Ruby �� HP �� ���炷
        controller.ChangeHealth(-damageAmount);
    }



    // �g���K�[�ݒ�� 2D �R���C�_�[�ɏՓ˂������ɌĂ΂��֐�

}
