using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;
    private float horizontal;
    private float vertical;
    public float speed = 3.0f;//移動速度
    private Animator animator;
    private Vector2 lookDirection = new Vector2(1, 0);

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d= GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //FixedUpdate()ではinput関連の入力を読み取るのは
        //禁止のため、update()で入力値を保存しておく
         horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        //入力値を代入
        Vector2 move = new Vector2(horizontal, vertical);
        //move.x、move.yの値が0.0fでない時は移動方向を設定する
        //※入力値がない場合でも今向いてる方向を保持しておきたいため
        if(!Mathf.Approximately(move.x,0.0f)||!Mathf.Approximately(move.y,0.0f))
        {
            lookDirection = move;
            lookDirection.Normalize();
        }
        //Animatorへパラメータを送信
        animator.SetFloat("LookX", lookDirection.x);
        animator.SetFloat("LookY", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        //Debug.Log(horizontal);//水平入力値をコンソールウィンドウへ出力
        Vector2 position = transform.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;
        transform.position = position;
    }
    void FixedUpdate()
    {
        Vector2 position = transform.position;

        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        //物理システムに位置を伝える
        rigidbody2d.MovePosition(position);

    }

}
