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
    private GameObject child;
    private Vector3 toDirection = new Vector3(1, 0, 0);
    private Vector3 TargetPosition;
    private Vector3 MePosition;
    private float length;
    

    void Start()
    {
        child = transform.GetChild(0).gameObject;
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
        Debug.Log(length);

        if (length < 14.0f)
        {
            if(child.GetComponent<SpriteRenderer>().material.color.a <= 0)
            {
                child.GetComponent<SpriteRenderer>().material.color = 
                    child.GetComponent<SpriteRenderer>().material.color + new Color32(0, 0, 0, 255);
            }
        }
        else
        {
            if(child.GetComponent<SpriteRenderer>().material.color.a > 0)
            {
                child.GetComponent<SpriteRenderer>().material.color = 
                    child.GetComponent<SpriteRenderer>().material.color - new Color32(0, 0, 0, 255);
            }
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