using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCount : MonoBehaviour
{
    //シングルトン用変数
    public static EnemyCount instance;

    //初期設定
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);

            Debug.Log("シングルトン生成");
        }
        else
        {
            Destroy(this.gameObject);
            Debug.Log("シングルトン破棄");
        }
    }

    //敵の情報を持つためのオブジェクト
    private GameObject[] enemyBox;

    //敵が全滅したときに立つフラグ
    public static bool annihilatedEnemy = false;

    //現在の敵の数
    public static int enemyCount = 0;


    //更新処理
    void Update()
    {
        enemyBox = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemyBox.Length == 0)
        {
            annihilatedEnemy = true;
            Debug.Log("敵全滅");
        }
        if(enemyBox.Length != enemyCount)
        {
            Debug.Log("敵の数:" + enemyBox.Length.ToString());
        }

        //配列数を記憶しておく
        enemyCount = enemyBox.Length;
    }

    public static bool GetAnnihilatedEnemy()
    {
        return annihilatedEnemy;
    }
}
