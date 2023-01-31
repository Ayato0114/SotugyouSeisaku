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
        // 0以上の整数がPointの数だけ並んだ配列
        int[] array1 = Enumerable.Range(0, transform.childCount).ToArray();
        // array1をシャッフルする
        int[] array2 = array1.OrderBy(i => Guid.NewGuid()).ToArray();

        // 配置するアイテムの数
        int count = Mathf.FloorToInt(transform.childCount * capacity);
        // アイテム配置
        for (int n = 0; n < count; n++)
        {
            Instantiate(item, transform.GetChild(array2[n]).position, item.transform.rotation);
        }
        // 破壊
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
