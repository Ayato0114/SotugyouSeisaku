using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemGet : MonoBehaviour
{
    public int ArrayNo { get; private set; }
    private void Awake()
    {
        gameObject.GetComponent<Button>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            for (int i = 0; i < ItemInventory.instance.isItem.Length; i++)
            {
                if (ItemInventory.instance.isItem[i] == false)
                {
                    MoveItem(i);
                    break;
                }
            }
        }
    }

    private void MoveItem(int i)
    {
        ArrayNo = i;
        ItemInventory.instance.isItem[i] = true;
        transform.position = ItemInventory.instance.ItemSlot[i].transform.position;
        gameObject.GetComponent<Button>().enabled = true;
    }
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
