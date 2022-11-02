using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YamaAxis : MonoBehaviour
{
    // Start is called before the first frame update

    public Vector3 up = new Vector3(0.0f, 0.0f, 1.0f);
    [SerializeField]
    GameObject target;
    Vector3 toDirection = new Vector3(1, 0, 0);
    public GameObject player;
    YamaRubyController controller;
    //private object SampleParent;

    void Start()
    {
        // 親のゲームオブジェクトを取得
        player = transform.parent.gameObject;
        controller = player.GetComponent<YamaRubyController>();
    }

    // Update is called once per frame
    void Update()
    {
        //toDirection = target.transform.position - transform.position;

        //transform.position = Ruby.transform.position;

        // Rubyの方向ベクトルを代入
        toDirection.x = controller.lookDirection.x;
        toDirection.y = controller.lookDirection.y;

        RotateObject();
    }

    void RotateObject()
    {
        transform.rotation = Quaternion.FromToRotation(Vector3.up, toDirection);
        //transform.Rotate(up * 0.2f);
    }
}