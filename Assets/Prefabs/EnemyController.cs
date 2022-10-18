using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update

    public bool vertical;//縦方向に移動するか

    public float speed = 3.0f;//移動速度

    public float changeTime = 3.0f;//移動方向を切り替えるまでの時間

    private float timer;
    private int direction = 1;//1なら前方向、-1なら後方向

    private Rigidbody2D rigidbody2d;

    private Animator animator;
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        timer = changeTime;
        animator = GetComponent<Animator>();
    }
       
    
    // Update is called once per frame
     void Update()
    {
        //一定間隔で移動方向を逆方向にする
        timer -= Time.deltaTime;
        if(timer<0)
        {
            direction = -direction;
            timer = changeTime;
        }
    }
    void FixedUpdate()
    {
        Vector2 position = transform.position;

        if(vertical)
        {
            //縦方向の移動処理
            position.y = position.y + speed * Time.deltaTime * direction;
            //アニメーターにパラメータを送信
            animator.SetFloat("MoveX", 0);
            animator.SetFloat("MoveY", direction);
        }
        else
        {
            //横方向の移動処理
            position.x = position.x + speed * Time.deltaTime * direction;
            //アニメーターにパラメータを送信
            animator.SetFloat("MoveX", direction);
            animator.SetFloat("MoveY", 0);
        }
        //物理システムに位置を伝える
        rigidbody2d.MovePosition(position);

    }
}



    
