using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private GameObject playObject;
    private Vector3 playTrans;                  //���@��Transform

    [SerializeField] List<GameObject> playerList;    // �����I�u�W�F�N�g
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
        //playObject = GameObject.FindWithTag("Player");
        //if (playObject == null)
        //{
        //    playTrans.x = 0;
        //    playTrans.y = 0;
        //    playTrans.z = 0;
        //}
        //else
        //{
        //    playTrans = playObject.transform.position;
        //}

        if (!enemyAlive)
        {
            enemyAlive = true;
            // �����_���Ŏ�ނƈʒu�����߂�
            int index = Random.Range(0, playerList.Count);
            float posX = Random.Range(minX, maxX);
            float posY = Random.Range(minY, maxY);
            Instantiate(playerList[index], new Vector3(posX, posY, 0), Quaternion.identity);
        }


    }



}
