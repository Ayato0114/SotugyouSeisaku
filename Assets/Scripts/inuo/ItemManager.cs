using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    static ItemManager instance;
    public static ItemManager GetInstance()
    {
        return instance;
    }
    //　アイテムデータベース
    [SerializeField]
    private inuo_itemDataBase itemDataBase;
    //　アイテム数管理
    private Dictionary<inuo_item, int> numOfItem = new Dictionary<inuo_item, int>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < itemDataBase.GetItemLists().Count; i++)
        {
            instance = this;
            //　アイテム数を適当に設定
            numOfItem.Add(itemDataBase.GetItemLists()[i], i);
            //　確認の為データ出力
            Debug.Log(itemDataBase.GetItemLists()[i].GetItemName() + ": " + itemDataBase.GetItemLists()[i].GetInformation());
        }
        //Debug.Log(numOfItem[GetItem("薬草")]);
    }

    //　名前でアイテムを取得
    public inuo_item GetItem(string searchName)
    {
        return itemDataBase.GetItemLists().Find(itemName => itemName.GetItemName() == searchName);
    }
        // Update is called once per frame
        void Update()
    {
        
    }

    public bool HasItem(string searchName)
    {  
        return itemDataBase.GetItemLists().Exists(item => item.GetItemName() == searchName);
    }
}
