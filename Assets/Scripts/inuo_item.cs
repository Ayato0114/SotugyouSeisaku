using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Item", menuName = "CreateItem")]
public class inuo_item : ScriptableObject
{
    public enum ItemType // 実装するItemの種類
    {
        UserItem,
        //CraftItem,
        //KeyItem,
    }

    //　アイテムの種類
    [SerializeField]
    private ItemType itemType;
    //　アイテムのアイコン
    [SerializeField]
    private Sprite icon;
    //　アイテムの名前
    [SerializeField]
    private string itemName;
    //　アイテムの情報
    [SerializeField]
    private string information;

    public ItemType GetKindOfItem()
    {
        return itemType;
    }

    public Sprite GetIcon()
    {
        return icon;
    }

    public string GetItemName()
    {
        return itemName;
    }

    public string GetInformation()
    {
        return information;
    }

    //public Type type; // 種類
    //public String infomation; // 情報
    //public Sprite sprite; // 画像

    //public inuo_item(inuo_item item)
    //{
    //    this.type = item.type;
    //    this.infomation = item.infomation;
    //    this.sprite = item.sprite; 
    //}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
