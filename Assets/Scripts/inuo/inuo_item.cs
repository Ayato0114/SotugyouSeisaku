using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Item", menuName = "CreateItem")]
public class inuo_item : ScriptableObject
{
    public enum ItemType // ��������Item�̎��
    {
        UserItem,
        //CraftItem,
        //KeyItem,
    }

    //�@�A�C�e���̎��
    [SerializeField]
    private ItemType itemType;
    //�@�A�C�e���̃A�C�R��
    [SerializeField]
    private Sprite icon;
    //�@�A�C�e���̖��O
    [SerializeField]
    private string itemName;
    //�@�A�C�e���̏��
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

    //public Type type; // ���
    //public String infomation; // ���
    //public Sprite sprite; // �摜

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
