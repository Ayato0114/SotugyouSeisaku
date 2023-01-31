using UnityEngine;
public class MasterData : MonoBehaviour
{
    public static FieldDataTable FieldDataTable { get; private set; }
    public static StageDataTable StageDataTable { get; private set; }
    [SerializeField]
    private FieldDataTable fieldDataTable;
    [SerializeField]
    private StageDataTable stageDataTable;
    public void Awake()
    {
        FieldDataTable = fieldDataTable;
        StageDataTable = stageDataTable;
    }
}