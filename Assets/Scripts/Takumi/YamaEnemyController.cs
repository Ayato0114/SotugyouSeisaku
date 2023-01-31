using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YamaEnemyController : MonoBehaviour
{
    // Start is called before the first frame update

    public bool vertical;//縦方向に移動するか

    public float speed = 3.0f;//移動速度

    public float changeTime = 3.0f;//移動方向を切り替えるまでの時間

    private float timer;
    private int direction = 1;//1なら前方向、-1なら後方向

    private Rigidbody2D rigidbody2d;

    private Animator animator;

    // ターン制テスト用
    public GameObject target;


    private bool isInvincible; //無敵状態か
    private float invincibleTimer; //残り無敵時間

    public float timeInvincible = 2.0f; //無敵時間
    public int maxHealth = 5;   //最大HP
    private int currentHealth;

    private bool frg = false;

    public int health
    {
        get { return currentHealth; }
    }

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        timer = changeTime;
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
    }


    // Update is called once per frame
    void Update()
    {
        // ターン制テスト用
        
        if (frg)
        {
            //一定間隔で移動方向を逆方向にする
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                direction = -direction;
                timer = changeTime;
            }
        }

        frg = target.GetComponent<YamaRubyController>().frg;
    }
    void FixedUpdate()
    {
        // ターン制テスト用
        if (frg)
        {
            Vector2 position = transform.position;

            if (vertical)
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
        else
        {
            animator.SetFloat(0, 0);
            animator.SetFloat(0, 0);
        }
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible) return;
            isInvincible = true;
            invincibleTimer = timeInvincible;
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }
}




