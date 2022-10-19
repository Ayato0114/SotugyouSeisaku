using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inuo_RubyController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rigidbody2d;
    private float horizontal;
    private float vertical;
    private bool isInvincible; //–³“Gó‘Ô‚©
    private float invincibleTimer; //c‚è–³“GŠÔ

    public float timeInvincible = 2.0f; //–³“GŠÔ
    public int maxHealth = 5;   //Å‘åHP
    private int currentHealth;

    public int health
    {
        get { return currentHealth; }
    }
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();

        currentHealth = maxHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        
        // –³“GŠÔXVˆ—
        if(isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if(invincibleTimer < 0)
            {
                isInvincible = false;
            }
        }
       

       
      
    }
    private void FixedUpdate()
    {
        Vector2 position = transform.position;
        position.x = position.x + 3.0f * horizontal * Time.deltaTime;
        position.y = position.y + 3.0f * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }

    //Œ’Nó‘Ô‚ğ•ÏX
    public void ChangeHealth(int amount)
    {
        if(amount < 0)
        {
            if (isInvincible) return;
            isInvincible = true;
            invincibleTimer = timeInvincible;
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }
}
