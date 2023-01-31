using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    //Exit�ɓ��B�������ǂ���
    private bool exitFlag = false;

    //Exit�^�C���ɏ�������ɌĂяo�����֐�
    private void OnTriggerEnter2D(Collider2D collider)
    {
        //�܂����B���ĂȂ�
        if (!exitFlag)
        {
            //Player�^�O�̕t���Ă���I�u�W�F�N�g���������
            if (collider.tag.Contains("Player"))
            {
                //���x���t���O�������Ȃ��悤�ɂ���
                exitFlag = true;

            }
        }
    }
}
