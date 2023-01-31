using UnityEngine;
public class Tomoya_GameManager : MonoBehaviour
{
    // �Q�[���J�n������̃V�[���ǂݍ��ݑO�ɌĂ΂��悤�ɂ��鑮�����w��
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void InitializeBeforeSceneLoad()
    {
        // Resources �t�H���_���� GameManager �v���n�u��ǂݍ���
        var gameManagerPrefab = Resources.Load<GameManager>("   ");
        // �Q�[�����ɏ�ɑ��݂���I�u�W�F�N�g�𐶐�
        var gameManager = Instantiate(gameManagerPrefab);
        // �V�[���̕ύX���ɂ��j������Ȃ��悤�ɂ���
        DontDestroyOnLoad(gameManager);
    }
}