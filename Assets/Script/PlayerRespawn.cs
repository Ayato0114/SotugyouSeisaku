using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
  
    [SerializeField] List<GameObject> playerList;    // 生成オブジェクト
    [SerializeField] float MinPosX = -10;                 // 生成位置
    [SerializeField] float MinPosY = -10;                 // 生成位置
    [SerializeField] float MaxPosX = 10;                 // 生成位置
    [SerializeField] float MaxPosY = 10;                 // 生成位置
    float minX, maxX, minY, maxY;                   // 生成範囲


    bool playerAlive = false;

    // Start is called before the first frame update
    void Start()
    {
        minX = Mathf.Min(MaxPosX, MinPosX);
        maxX = Mathf.Max(MaxPosX, MinPosX);
        minY = Mathf.Min(MaxPosY, MinPosY);
        maxY = Mathf.Max(MaxPosY, MinPosY);
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

        if (!playerAlive)
        {
            playerAlive = true;
            // ランダムで種類と位置を決める
            int index = Random.Range(0, playerList.Count);
            float posX = Random.Range(minX, maxX);
            float posY = Random.Range(minY, maxY);
            Instantiate(playerList[index], new Vector3(posX, posY, 0), Quaternion.identity);
        }


    }



}
