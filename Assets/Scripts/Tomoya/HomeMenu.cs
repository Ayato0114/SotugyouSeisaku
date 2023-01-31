using UnityEngine;
using UnityEngine.UI;
public class HomeMenu : MonoBehaviour
{
    [SerializeField]
    private Transform stageItemParent;
    [SerializeField]
    private GameObject stageItemPrefab;

    

    private void Start()
    {

        // すべてのクエストデータを取り出し、クエストボードにアイテムを生成
        foreach (StageData stageData in MasterData.StageDataTable.Stages)
        {
            Instantiate(stageItemPrefab, stageItemParent);
        }
    }

}