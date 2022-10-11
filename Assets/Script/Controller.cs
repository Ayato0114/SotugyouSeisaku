using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        //Debug.Log(horizontal);//水平入力値をコンソールウィンドウへ出力
        Vector2 positon = transform.position;
        positon.x = positon.x +3.0f*horizontal*Time.deltaTime;
        positon.y = positon.y +3.0f * vertical * Time.deltaTime;
        transform.position = positon;
    }
}
