using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YamaDamageZone : MonoBehaviour
{
    public int damageAmount = 1;        // ダメージ量 
    public float timeInvincible = 2.0f; // クールタイム
    private bool isInvincible;          // クールタイムか
    private float invincibleTimer;      // 残り時間

    void Update()
    {
        // クールタイムの更新処理
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
            {
                isInvincible = false;
            }
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // 衝突した相手が Ruby か判定する
        YamaRubyController controller = collision.GetComponent<YamaRubyController>();
        if (controller != null)
        {
            if (isInvincible) return;
            isInvincible = true;
            invincibleTimer = timeInvincible;

            Damage(controller);
        }

    }

    public void Damage(YamaRubyController controller)
    {
        // Ruby の HP を 減らす
        controller.ChangeHealth(-damageAmount);
    }



    // トリガー設定の 2D コライダーに衝突した時に呼ばれる関数

}
