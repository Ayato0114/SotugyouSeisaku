using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDataBase", menuName = "CreateItemDataBase")]
public class inuo_itemDataBase : ScriptableObject
{
    [SerializeField]
    private List<inuo_item> itemLists = new List<inuo_item>();

    //　アイテムリストを返す
    public List<inuo_item> GetItemLists()
    {
        return itemLists;
    }
    //public List<inuo_item> items = new List<inuo_item>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
