using UnityEngine;

public class SceneSwitchClear : MonoBehaviour
{
    //Exit�ɓ��B�������ǂ���
    private bool exitFlag = false;

    //Exit�^�C���ɏ�������ɌĂяo�����֐�
    private void OnTrggerEnter2D(Collider2D other)
    {
        //�܂����B���ĂȂ�
        if(!exitFlag)
        {
            //Player�^�O�̕t���Ă���I�u�W�F�N�g���������
            if(other.tag.Contains("Player"))
            {
                exitFlag = true;
            }
        }
    }


}
