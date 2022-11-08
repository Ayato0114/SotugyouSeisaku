using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YamaEnemyAxis : MonoBehaviour
{
    // Start is called before the first frame update

    private Vector3 up = new Vector3(0.0f, 0.0f, 1.0f);
    [SerializeField]
    public GameObject target;
    public GameObject me;
    private Vector3 toDirection = new Vector3(1, 0, 0);
    private Vector3 TargetPosition;
    private Vector3 MePosition;
    private float length;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // ターゲットのゲームオブジェクトから位置取得
        TargetPosition = target.transform.position;

        // 自身(今は親)のゲームオブジェクトから位置取得
        MePosition = me.transform.position;
        MePosition.y += 1.0f;


        toDirection = MePosition - TargetPosition;

        length = toDirection.magnitude;
        Debug.Log(toDirection.magnitude);

        if (length < 14.0f)
        {
            gameObject.SetActive(true);
        }
        else
        {
            //gameObject.SetActive(false);
        }

        toDirection.Normalize();


        RotateObject();
        transform.position = TargetPosition;
    }

    void RotateObject()
    {
        transform.rotation = Quaternion.FromToRotation(Vector3.up, toDirection);
    }
}