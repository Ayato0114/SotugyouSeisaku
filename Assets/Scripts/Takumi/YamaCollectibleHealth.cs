using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YamaCollectibleHealth : MonoBehaviour
{
    public int recoveryAmount = 1;  // �񕜗�


    // �g���K�[�ݒ�� 2D �R���C�_�[�ɏՓ˂������ɌĂ΂��֐�
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("�g���K�[�ɐN�����Ă���I�u�W�F�N�g : " + collision);
        // �Փ˂������肪 Ruby �����肷��
        YamaRubyController controller = collision.GetComponent<YamaRubyController>();
        if (controller != null)
        {
            // Ruby �� HP �� 1 ���₷
            controller.ChangeHealth(recoveryAmount);

            // ���g���폜����
            Destroy(gameObject);
        }

    }

}
