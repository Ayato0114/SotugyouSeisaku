using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update

    public bool vertical;//縦方向に移動するか

    public float speed = 3.0f;//移動速度

    public float changeTime = 3.0f;//移動方向を切り替えるまでの時間


    public float span = 2.0f;

    private float timer;
    private float timer_2;
    private int direction = 1;//1なら前方向、-1なら後方向

    private Rigidbody2D rigidbody2d;

    private Animator animator;


    private bool isInvincible; //無敵状態か
    private float invincibleTimer; //残り無敵時間

    public float timeInvincible = 2.0f; //無敵時間
    [SerializeField] public int maxHealth;   //最大HP
    private int currentHealth;

    public UnityEvent OnDestroyed = new UnityEvent();

    private GameObject enemy;

    private GameObject player;

    [SerializeField] public GameObject enemyProjectilePrefab;
    [SerializeField] public GameObject enemyProjectilePrefab_kinsetu;


    //[SerializeField]  float attackDistance = 2;


    //[SerializeField] float chaseDistance = 5;

    //[SerializeField] Transform target = null;   

    //Transform defaultTarget;

    //bool isAttacking = false;

    private Vector2 lookDirection = new Vector2(1, 0);
    private Vector2 lookDirection2 = new Vector2(0, 1);

    [SerializeField] public float length=4.0f;
    private float timeflag = 0.0f;


    public int health
    {
        get { return currentHealth; }
    }

    void Start()
    {



        player = GameObject.FindWithTag("Player");
        enemy = GameObject.FindWithTag("Enemy"); 
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
        timer_2 += Time.deltaTime;
        if (timer < 0)
            if (timer < 0)
            {

                lookDirection = -lookDirection;
                lookDirection2 = -lookDirection2;
                direction = -direction;
                timer = changeTime;
            }



       float v= Mathf.Sqrt(((player.transform.position.x - enemy.transform.position.x) * (player.transform.position.x - enemy.transform.position.x)) + ((player.transform.position.y - enemy.transform.position.y) * (player.transform.position.y - enemy.transform.position.y)));





        if (timer_2 > span)
        {
            timer_2 = 0;
            timeflag = 0;
            Lanch();
        }


            if (v <length)
        {
            

            if(timeflag==0)
            {
                timeflag = 1;
                Attack2();

            }
               
            
        }
    }

    void FixedUpdate()
    {
        Vector2 position = transform.position;

        //float diff = (player.transform.position - enemy.transform.position).sqrMagnitude;
        //// 距離を比較。比較対象も二乗するのを忘れずに
        //if (diff < attackDistance * attackDistance)
        //{
        //    if (!isAttacking)
        //    {
        //        StartCoroutine(nameof(Attack));
        //    }
        //}
        //else if (diff < chaseDistance * chaseDistance)
        //{
        //    target = player.transform;
        //}
        //else
        //{
        //    target = defaultTarget;
        //}


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


    void Lanch()
    {

        //プレハブからオブジェクトを生成
        GameObject projectileObject = Instantiate
            (enemyProjectilePrefab,
            rigidbody2d.position + Vector2.up * 0.5f,
            Quaternion.identity);
        //Projectileコンポーネントに発射命令
        EnemyLunch tama = projectileObject.GetComponent<EnemyLunch>();
        tama.Lanch(lookDirection, 300);


    }

    void Attack2()
    {
        if (vertical)
        {



            //プレハブからオブジェクトを生成
            GameObject projectileObject = Instantiate
           (enemyProjectilePrefab_kinsetu,
           rigidbody2d.position + Vector2.up * 0.5f,
           Quaternion.identity);
            //Projectileコンポーネントに発射命令
            EnemyAttack enemy_attack = projectileObject.GetComponent<EnemyAttack>();
            enemy_attack.Attack2(lookDirection2, 1000);
        }
        else
        {
            //プレハブからオブジェクトを生成
            GameObject projectileObject = Instantiate
           (enemyProjectilePrefab_kinsetu,
           rigidbody2d.position + Vector2.up * 0.5f,
           Quaternion.identity);
            //Projectileコンポーネントに発射命令
            EnemyAttack enemy_attack = projectileObject.GetComponent<EnemyAttack>();
            enemy_attack.Attack2(lookDirection, 1000);
        }



    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Controller player = collision.gameObject.GetComponent<Controller>();
        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }

    private void OnDestroy()
    {
        Debug.Log("Destroyed");
        OnDestroyed.Invoke();
    }

    
}



    
