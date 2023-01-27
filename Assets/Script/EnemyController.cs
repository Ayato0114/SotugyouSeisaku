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


    private bool isInvincible; //無敵状態か
    private float invincibleTimer; //残り無敵時間

    public float timeInvincible = 2.0f; //無敵時間
    [SerializeField]  public int maxHealth ;   //最大HP
    private int currentHealth;



    private GameObject enemy;

    private GameObject target;


   


    public int health
    {
        get { return currentHealth; }
    }

    void Start()
    {
      


        target = GameObject.Find("Player");
        enemy = GameObject.Find("Enemy");
        rigidbody2d = GetComponent<Rigidbody2D>();
        timer = changeTime;
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
    }


    // Update is called once per frame
    void Update()
    {

        //一定間隔で移動方向を逆方向にする
        timer -= Time.deltaTime;
        if (timer < 0)
            if (timer < 0)
            {
                direction = -direction;
                timer = changeTime;
            }

    }

    void FixedUpdate()
    {
        Vector2 position = transform.position;

       

        ////プレイヤー-敵キャラの位置関係から方向を取得し、速度を一定化
        //Vector2 targeting = (target.transform.position - transform.position).normalized;
        //if (targeting.x > 0)
        //{
        //    this.GetComponent<SpriteRenderer>().flipX = true;
        //}
        //else
        //{
        //    this.GetComponent<SpriteRenderer>().flipX = false;
        //}
        ////x方向にのみプレイヤーを追う
        //this.GetComponent<Rigidbody2D>().velocity = new Vector2((targeting.x * 5), 0);

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



    
