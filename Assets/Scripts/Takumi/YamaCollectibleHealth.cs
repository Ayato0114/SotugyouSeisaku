using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YamaCollectibleHealth : MonoBehaviour
{
    public int recoveryAmount = 1;  // 回復量


    // トリガー設定の 2D コライダーに衝突した時に呼ばれる関数
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("トリガーに侵入しているオブジェクト : " + collision);
        // 衝突した相手が Ruby か判定する
        YamaRubyController controller = collision.GetComponent<YamaRubyController>();
        if (controller != null)
        {
            // Ruby の HP を 1 増やす
            controller.ChangeHealth(recoveryAmount);

            // 自身を削除する
            Destroy(gameObject);
        }

    }

}
