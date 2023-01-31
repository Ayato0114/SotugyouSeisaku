using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCount : MonoBehaviour
{
    //�V���O���g���p�ϐ�
    public static EnemyCount instance;

    //�����ݒ�
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);

            Debug.Log("�V���O���g������");
        }
        else
        {
            Destroy(this.gameObject);
            Debug.Log("�V���O���g���j��");
        }
    }

    //�G�̏��������߂̃I�u�W�F�N�g
    private GameObject[] enemyBox;

    //�G���S�ł����Ƃ��ɗ��t���O
    public static bool annihilatedEnemy = false;

    //���݂̓G�̐�
    public static int enemyCount = 0;


    //�X�V����
    void Update()
    {
        enemyBox = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemyBox.Length == 0)
        {
            annihilatedEnemy = true;
            Debug.Log("�G�S��");
        }
        if(enemyBox.Length != enemyCount)
        {
            Debug.Log("�G�̐�:" + enemyBox.Length.ToString());
        }

        //�z�񐔂��L�����Ă���
        enemyCount = enemyBox.Length;
    }

    public static bool GetAnnihilatedEnemy()
    {
        return annihilatedEnemy;
    }
}
