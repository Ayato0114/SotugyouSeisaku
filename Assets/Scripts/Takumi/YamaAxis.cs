using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YamaAxis : MonoBehaviour
{
    // Start is called before the first frame update

    private Vector3 up = new Vector3(0.0f, 0.0f, 1.0f);
    [SerializeField]
    public GameObject target;
    private Vector3 toDirection = new Vector3(1, 0, 0);
    private GameObject player;
    private YamaRubyController controller;

    void Start()
    {
        // プレイヤーのゲームオブジェクトを取得
        player = target;
        controller = player.GetComponent<YamaRubyController>();

        //controller = target.GetComponent<YamaRubyController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Rubyの方向ベクトルを代入
        toDirection.x = controller.lookDirection.x;
        toDirection.y = controller.lookDirection.y;

        RotateObject();
    }

    void RotateObject()
    {
        transform.rotation = Quaternion.FromToRotation(Vector3.up, toDirection);
    }
}