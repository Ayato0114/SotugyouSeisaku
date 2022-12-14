using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private GameObject playObject;
    private Vector3 playTrans;                  //自機のTransform

    [SerializeField] List<GameObject> playerList;    // 生成オブジェクト
    Transform pos;                 // 生成位置
    Transform pos2;                // 生成位置
    float minX, maxX, minY, maxY;                   // 生成範囲


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
            // ランダムで種類と位置を決める
            int index = Random.Range(0, playerList.Count);
            float posX = Random.Range(minX, maxX);
            float posY = Random.Range(minY, maxY);
            Instantiate(playerList[index], new Vector3(posX, posY, 0), Quaternion.identity);
        }


    }



}
