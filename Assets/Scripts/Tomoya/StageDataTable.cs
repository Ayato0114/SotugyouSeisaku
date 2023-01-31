using System;
using UnityEngine;

[CreateAssetMenu(menuName = "RandomLabyrinth/StageDataTable",
    fileName = "StageDataTable")]
public class StageDataTable : ScriptableObject
{
    public StageData[] Stages;  
}

[Serializable]
public class StageData
{
    public int Id;
    public string Name;
    public int FieldId;
}

