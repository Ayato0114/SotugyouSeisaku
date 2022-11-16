using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItem : MonoBehaviour
{
    
    private SpriteRenderer Player;
    // Start is called before the first frame update
    void Start()
    {
       
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
    }

    public void Use()
    {
        int i = gameObject.GetComponent<ItemGet>().ArrayNo;
        ItemInventory.instance.isItem[i] = false;
        Player.color = Color.red;
        Destroy(gameObject);
    }

    public void Use2()
    {
        int i = gameObject.GetComponent<ItemGet>().ArrayNo;
        ItemInventory.instance.isItem[i] = false;
        Player.color = Color.green;
        Destroy(gameObject);     
    }
    // Update is called once per frame
    void Update()
    {
         
    }

    public void Use3()
    {
        int i = gameObject.GetComponent<ItemGet>().ArrayNo;
        ItemInventory.instance.isItem[i] = false;
        
        Destroy(gameObject);
    }
}