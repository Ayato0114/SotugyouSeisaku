using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YamaRubyController : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;
    private float horizontal;
    private float vertical;
    public float speed = 3.0f;//移動速度
    private Animator animator;
    private Vector2 lookDirection = new Vector2(1, 0);

    private bool isInvincible; //無敵状態か
    private float invincibleTimer; //残り無敵時間

    public float timeInvincible = 2.0f; //無敵時間
    public int maxHealth = 5;   //最大HP
    private int currentHealth;

    // Start is called before the first frame update

    public int health
    {
        get { return currentHealth; }
    }

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
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
        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
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

        // 無敵時間更新処理
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
            {
                isInvincible = false;
            }
        }
    }
    void FixedUpdate()
    {
        Vector2 position = transform.position;

        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

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

    private void OnTriggerStay2D(Collider2D collision)
    {
        EnemyController enemy_controllers = collision.GetComponent<EnemyController>();
        if (enemy_controllers != null)
        {
            enemy_controllers.ChangeHealth(-1);

            if (enemy_controllers.health == 0)
            {
                Destroy(enemy_controllers.gameObject);
            }
        }
    }
}


