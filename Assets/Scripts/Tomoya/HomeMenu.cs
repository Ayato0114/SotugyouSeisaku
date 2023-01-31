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

        // ���ׂẴN�G�X�g�f�[�^�����o���A�N�G�X�g�{�[�h�ɃA�C�e���𐶐�
        foreach (StageData stageData in MasterData.StageDataTable.Stages)
        {
            Instantiate(stageItemPrefab, stageItemParent);
        }
    }

}