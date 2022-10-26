using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    //public float timeInvincible = 2.0f; // 無敵時間
    //private bool isInvincible; // 無敵状態か
    //private float invincibleTimer; // 残り無敵時間

    public int maxHealth = 10; // 最大 HP
    private int currentHealth; // 現在の HP
    //public float speed = 1.0f;

    public Vector2 speed = new Vector2(0.0f, 0.0f);


    private Rigidbody2D rigidbody2d;
    private float horizontal;
    private float vertical;
    // Update()が呼ばれる前に一度だけ呼ばれる関数
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();

        // ゲーム開始時に HP を初期化する
        currentHealth = maxHealth;

        //currentHealth = 1;
    }

    // 健康状態を変更する
    public void ChangeHealth(int amount)
    {
        //if (amount < 0)
        //{
        //    if (isInvincible) return;
        //    isInvincible = true;
        //    invincibleTimer = timeInvincible;
        //}

        // 現在の HP を 0～maxHealth の間に収まるように変更する
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }

    // 毎フレーム呼ばれる関数
    void Update()
    {
        // FixedUpdate()では Input 関連の入力を読み取るのは
        // 禁止のため、Update()で入力値を保存しておく
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        speed.x = 15.0f * horizontal * Time.deltaTime;
        speed.y = 15.0f * vertical * Time.deltaTime;

        // 無敵時間の更新処理
        //if (isInvincible)
        //{
        //    invincibleTimer -= Time.deltaTime;
        //    if (invincibleTimer < 0)
        //    {
        //        isInvincible = false;
        //    }
        //}

    }

    // 一定時間毎に呼ばれる関数
    void FixedUpdate()
    {

        Vector2 position = transform.position;
        //Vector2 position = rigidbody2d.AddForce(speed);
        rigidbody2d.AddForce(speed);
        

        position.x = position.x + speed.x;
        position.y = position.y + speed.y;


        // 物理システムに位置を伝える
        rigidbody2d.MovePosition(position);
    }

    private Vector2 Vector2(object p, float v)
    {
        throw new NotImplementedException();
    }
}
