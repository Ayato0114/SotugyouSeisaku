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

    //敵の情報を持つためのオブジェクト
    private GameObject[] enemyBox;

    //敵が全滅したときに立つフラグ
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
