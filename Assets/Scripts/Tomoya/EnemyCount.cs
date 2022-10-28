using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCount : MonoBehaviour
{
    //�G�̏��������߂̃I�u�W�F�N�g
    private GameObject[] enemyBox;

    //�G���S�ł����Ƃ��ɗ��t���O
    private bool annihilatedEnemy = false;

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
