using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCount : MonoBehaviour
{
    public static EnemyCount instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    //�G�̏��������߂̃I�u�W�F�N�g
    private GameObject[] enemyBox;

    //�G���S�ł����Ƃ��ɗ��t���O
    public static bool annihilatedEnemy = false;
   

    void Update()
    {
        enemyBox = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemyBox.Length == 0)
        {
            annihilatedEnemy = true;
        }
    }

    bool GetAnnihilatedEnemy()
    {
        return annihilatedEnemy;
    }
}
