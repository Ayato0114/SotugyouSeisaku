using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{
    [SerializeField] List<GameObject> enemyList;    // �����I�u�W�F�N�g
    Transform pos;                 // �����ʒu
     Transform pos2;                // �����ʒu
    float minX, maxX, minY, maxY;                   // �����͈�


    bool enemyAlive = false;
    
    // Start is called before the first frame update
    void Start()
    {
        minX = Mathf.Min(-10, -10);
        maxX = Mathf.Max(10, 10);
        minY = Mathf.Min(-10, -10);
        maxY = Mathf.Max(10, 10);
    }

    // Update is called once per frame
    void Update()
    {
        if(!enemyAlive)
        {
            enemyAlive = true;
            // �����_���Ŏ�ނƈʒu�����߂�
            int index = Random.Range(0, enemyList.Count);
            float posX = Random.Range(minX, maxX);
            float posY = Random.Range(minY, maxY);
            Instantiate(enemyList[index], new Vector3(posX, posY, 0), Quaternion.identity);
        }
          
       
    }
      

     
}
