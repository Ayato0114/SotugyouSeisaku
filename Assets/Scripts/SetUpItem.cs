using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class SetUpItem : MonoBehaviour
{
    [SerializeField] GameObject item;
    [SerializeField] [Range(0f, 1f)] float capacity;

    // Start is called before the first frame update
    void Start()
    {
        // 0�ȏ�̐�����Point�̐��������񂾔z��
        int[] array1 = Enumerable.Range(0, transform.childCount).ToArray();
        // array1���V���b�t������
        int[] array2 = array1.OrderBy(i => Guid.NewGuid()).ToArray();

        // �z�u����A�C�e���̐�
        int count = Mathf.FloorToInt(transform.childCount * capacity);
        // �A�C�e���z�u
        for (int n = 0; n < count; n++)
        {
            Instantiate(item, transform.GetChild(array2[n]).position, item.transform.rotation);
        }
        // �j��
        Destroy(gameObject);
        /*
        int n = 0;
        foreach (int i in ary2)
        {
            if (n < count)
            {
                Instantiate(item, transform.GetChild(i).position, item.transform.rotation);
            }
            Destroy(transform.GetChild(i).gameObject);
        }
        */
    }
    // Start is called before the first frame update
   
    // Update is called once per frame
    void Update()
    {
        
    }
}
