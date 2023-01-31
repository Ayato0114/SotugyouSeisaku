using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class BoarManager : MonoBehaviour
{
    [System.Serializable]
    public class Count
    {
        public int minimum;
        public int maximum;

        public Count(int min, int max)
        {
            minimum = min;
            maximum = max;
        }
    }
    static int MapWidth = 50;
    static int MapHeight = 50;

    int[,] Map;
    
    const int wall = 9;
    const int road = 0;

    //
    public int columns = 8;
    public int rows = 8;
    public Count foodCount = new Count(1, 5); 　//アイテムの配置数
    

    public GameObject WallObject;
    public GameObject RoadObject;
    public GameObject exit;
    //
    public GameObject[] foodTiles; //アイテムプレハブ

    const int roomMinHeight = 5;
    const int roomMaxHeight = 10;

    const int homeRoomHeight = 30;
    const int homeRoomWidth = 40;
    const int homeRoomPointX = 5;
    const int homeRoomPointY = 10;

    const int roomMinWidth = 5;
    const int roomMaxWidth = 10;

    const int RoomCountMin = 10;
    const int RoomCountMax = 15;

    public static bool isHome = false;

    private int exitPosX = 0;
    private int exitPosY = 0;

    private int posx;
    private int posy;
    //
    private Transform boardHolder;
    //
    private List<Vector3> gridPositions = new List<Vector3>(); //ランダム配置可能な位置リスト
    // 道の集合点
    const int meetPointCount = 1;


    // Mapの二次元配列の初期化
    private void ResetMapData()
    {
        Map = new int[MapHeight, MapWidth];
        for (int i = 0; i < MapHeight; i++)
        {
            for (int j = 0; j < MapWidth; j++)
            {
                Map[i, j] = wall;
            }
        }
    }

    // 空白部分のデータを変更
    private void CreateSpaceData()
    {
        int roomCount = Random.Range(RoomCountMin, RoomCountMax);

        int[] meetPointX = new int[meetPointCount];
        int[] meetPointY = new int[meetPointCount];
        for (int i = 0; i < meetPointX.Length; i++)
        {
            meetPointX[i] = Random.Range(MapWidth / 4, MapWidth * 3 / 4);
            meetPointY[i] = Random.Range(MapHeight / 4, MapHeight * 3 / 4);
            Map[meetPointY[i], meetPointX[i]] = road;
        }

        for (int i = 0; i < roomCount; i++)
        {
            int roomHeight = Random.Range(roomMinHeight, roomMaxHeight);
            int roomWidth = Random.Range(roomMinWidth, roomMaxWidth);
            int roomPointX = Random.Range(2, MapWidth - roomMaxWidth - 2);
            int roomPointY = Random.Range(2, MapWidth - roomMaxWidth - 2);

            int roadStartPointX = Random.Range(roomPointX, roomPointX + roomWidth);
            int roadStartPointY = Random.Range(roomPointY, roomPointY + roomHeight);

            bool isRoad = false;
            if (isHome == false)
            {
                isRoad = CreateRoomData(roomHeight, roomWidth, roomPointX, roomPointY);
                if (isRoad == false)
                {
                    CreateRoadData(roadStartPointX, roadStartPointY, meetPointX[Random.Range(0, 0)], meetPointY[Random.Range(0, 0)]);
                }
            }
            else
            {
                isRoad = CreateRoomData(homeRoomHeight, homeRoomWidth, homeRoomPointX, homeRoomPointY);
                if (isRoad == false)
                {
                    CreateRoadData(roadStartPointX, roadStartPointY, meetPointX[Random.Range(0, 0)], meetPointY[Random.Range(0, 0)]);
                }

            }

        }
    }

    // 部屋データを生成。すでに部屋がある場合はtrueを返し、道を作らないようにする
    private bool CreateRoomData(int roomHeight, int roomWidth, int roomPointX, int roomPointY)
    {
        bool isRoad = false;
        for (int i = 0; i < roomHeight; i++)
        {
            for (int j = 0; j < roomWidth; j++)
            {
                if (Map[roomPointY + i, roomPointX + j] == road)
                {
                    isRoad = true;
                }
                else
                {
                    Map[roomPointY + i, roomPointX + j] = road;
                }
                Instantiate(RoadObject, new Vector3((roomPointX + j) - MapWidth / 2, (roomPointY + i) - MapHeight / 2, 0), Quaternion.identity);
                exitPosX = Random.Range(roomPointX - MapWidth / 2, (roomPointX + i) - MapWidth / 2);
                exitPosY = Random.Range(roomPointY - MapHeight / 2, (roomPointY + i) - MapHeight / 2);

                posx = Random.Range(roomPointX - MapWidth / 2, (roomPointX + i) - MapWidth / 2);
                posy = Random.Range(roomPointX - MapWidth / 2, (roomPointX + i) - MapWidth / 2);
            }
        }
        return isRoad;
    }

    // 道データを生成
    private void CreateRoadData(int roadStartPointX, int roadStartPointY, int meetPointX, int meetPointY)
    {
        bool isRight;
        if (roadStartPointX > meetPointX)
        {
            isRight = true;
        }
        else
        {
            isRight = false;
        }
        bool isUnder;
        if (roadStartPointY > meetPointY)
        {
            isUnder = false;
        }
        else 
        {
            isUnder = true;
        }

        if (Random.Range(0, 2) == 0)
        {
            while (roadStartPointX != meetPointX)
            {
                Map[roadStartPointY, roadStartPointX] = road;
                if (isRight == true)
                {
                    roadStartPointX--;
                }
                else
                {
                    roadStartPointX++;
                }
                Instantiate(RoadObject, new Vector3(roadStartPointX - MapWidth / 2, roadStartPointY - MapHeight / 2, 0), Quaternion.identity);
            }

            while (roadStartPointY != meetPointY)
            {
                Map[roadStartPointY, roadStartPointX] = road;
                if (isUnder == true)
                {
                    roadStartPointY++;
                }
                else
                {
                    roadStartPointY--;
                }
                Instantiate(RoadObject, new Vector3(roadStartPointX - MapWidth / 2, roadStartPointY - MapHeight / 2, 0), Quaternion.identity);
            }
        }
        else
        {
            while (roadStartPointY != meetPointY)
            {
                Map[roadStartPointY, roadStartPointX] = road;
                if (isUnder == true)
                {
                    roadStartPointY++;
                }
                else
                {
                    roadStartPointY--;
                }
                Instantiate(RoadObject, new Vector3(roadStartPointX - MapWidth / 2, roadStartPointY - MapHeight / 2, 0), Quaternion.identity);
            }
            while (roadStartPointX != meetPointX)
            {
                Map[roadStartPointY, roadStartPointX] = road;
                if (isRight == true)
                {
                    roadStartPointX--;
                }
                else
                {
                    roadStartPointX++;
                }
                Instantiate(RoadObject, new Vector3(roadStartPointX - MapWidth / 2, roadStartPointY - MapHeight / 2, 0), Quaternion.identity);
            }
        }
    }

    // マップデータをもとにダンジョンを作成
    private void CreateDangeon()
    {
        for (int i = 0; i < MapHeight; i++)
        {
            for (int j = 0; j < MapWidth; j++)
            {
                if (Map[i, j] == wall)
                {
                    Instantiate(WallObject, new Vector3(j - MapWidth / 2, i - MapHeight / 2, 0), Quaternion.identity);
                }
            }
        }
    }

    // グリッドポジションからランダムの値を取得する

    void InitialiseList()
    {
        gridPositions.Clear();
        for (int x = 1; x < columns - 1; x++)
        {
            for (int y = 1; y < rows - 1; y++)
            {
                gridPositions.Add(new Vector3(x, y, 0f));
            }
        }
    }

    Vector3 RandomPosition()
    {
        int randomIndex = Random.Range(0, gridPositions.Count);
        Vector3 randomPosition = gridPositions[randomIndex];
        gridPositions.RemoveAt(randomIndex);

        return randomPosition;
    }

    void LayoutObjectAtRandom(GameObject[] prefabArray, int minimum, int maximum)
    {
        //配置数を決める
        int objectCount = Random.Range(minimum, maximum + 1);

        for (int i = 0; i < objectCount; i++)
        {
            Vector3 randomPosition = RandomPosition(); //配置する位置を取得
            GameObject prefabChoice = prefabArray[Random.Range(0, prefabArray.Length)];
            Instantiate(prefabChoice, randomPosition, Quaternion.identity);
        }
    }


    // 関数呼び出し
    public void SetupScene()
    {
        ResetMapData();

        CreateSpaceData();

        CreateDangeon();
        //ランダム配置できる位置リストを取得
        InitialiseList();
       

        transform.position = new Vector3(posx, posy, 0);

        bool isEnemy = EnemyCount.annihilatedEnemy;
        if (isEnemy == false)
        {
            Instantiate(exit, new Vector3(exitPosX, exitPosY, 0), Quaternion.identity);
        }

        LayoutObjectAtRandom(foodTiles, foodCount.minimum, foodCount.maximum);
    }


}
