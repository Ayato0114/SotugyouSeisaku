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
    //�@�A�C�e���f�[�^�x�[�X
    [SerializeField]
    private inuo_itemDataBase itemDataBase;
    //�@�A�C�e�����Ǘ�
    private Dictionary<inuo_item, int> numOfItem = new Dictionary<inuo_item, int>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < itemDataBase.GetItemLists().Count; i++)
        {
            instance = this;
            //�@�A�C�e������K���ɐݒ�
            numOfItem.Add(itemDataBase.GetItemLists()[i], i);
            //�@�m�F�̈׃f�[�^�o��
            Debug.Log(itemDataBase.GetItemLists()[i].GetItemName() + ": " + itemDataBase.GetItemLists()[i].GetInformation());
        }
        //Debug.Log(numOfItem[GetItem("��")]);
    }

    //�@���O�ŃA�C�e�����擾
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
