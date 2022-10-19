using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoarManager : MonoBehaviour
{
    public int colum = 8, rows = 8;

    private List<Vector3> gridPosition = new List<Vector3>();
    public GameObject[] floorTiles;
    public GameObject[] wallTiles;
    public GameObject[] foodTiles;
    public GameObject[] outWallTiles;

    public GameObject exit;

    public int wallMin = 5, wallMax = 9, foodMin = 1, foodMax = 5;


    void InitializeList()
    {
        gridPosition.Clear();

        for (int x = 1; x < colum - 1; x++)
        {
            for (int y = 1; y < rows - 1; y++)
            {
                gridPosition.Add(new Vector3(x, y, 0));
            }
        }
    }

    // 床の設定
    void BoardSetup()
    {
        // ポジション取得
        for (int x = -1; x < colum + 1; x++)
        {
            for (int y = -1; y < rows + 1; y++)
            {
                GameObject toInstantiate;

                // エリア外なら外壁を置く
                if (x == -1 || x == colum || y == -1 || y == rows)
                {
                    toInstantiate = outWallTiles[Random.Range(0, outWallTiles.Length)];
                }
                // そうでないなら床を置く
                else
                {
                    toInstantiate = floorTiles[Random.Range(0, floorTiles.Length)];
                }
                Instantiate(toInstantiate, new Vector3(x, y, 0), Quaternion.identity);
            }
        }
    }

    // グリッドポジションからランダムの値を取得する
    Vector3 RandomPosition()
    {
        int randomIndex = Random.Range(0, gridPosition.Count);

        Vector3 randomPosition = gridPosition[randomIndex];

        // 一度使用したポジションを消す
        gridPosition.RemoveAt(randomIndex);

        return randomPosition;
    }

    // アイテム設置
    void LayoutObjectatRandom(GameObject[] tileArray, int min, int max)
    {
        int objectCount = Random.Range(0, max + 1);

        for (int i = 0; i < objectCount; i++)
        {
            Vector3 randomPosition = RandomPosition();

            GameObject tileChoice = tileArray[Random.Range(0, tileArray.Length)];

            Instantiate(tileChoice, randomPosition, Quaternion.identity);
        }
    }

    // 関数呼び出し
    public void SetupScene()
    {
        BoardSetup();
        InitializeList();
        LayoutObjectatRandom(wallTiles, wallMin, wallMax);
        LayoutObjectatRandom(foodTiles, foodMin, foodMax);

        Instantiate(exit, new Vector3(colum - 1, rows - 1, 0), Quaternion.identity);
    }
}
