using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackControllerTest : MonoBehaviour
{
    Rigidbody2D rd; //Rigidbodyオブジェクト
    float attspeed = 6.0f;  //オブジェクト移動スピード

    void Start()
    {
        rd = GetComponent<Rigidbody2D>();   //Rigidbodyコンポーネント取得
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))     //攻撃開始時(Cキーを押すと攻撃開始)
            rd.velocity = new Vector2(attspeed, 0); //スピードをつけて攻撃オブジェクトを移動
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);    //攻撃オブジェクトの破棄
    }
}