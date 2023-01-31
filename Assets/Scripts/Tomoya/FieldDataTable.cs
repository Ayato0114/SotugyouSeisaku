using System;
using UnityEngine;

[CreateAssetMenu(menuName = "RandomLabyrinth/FieldDataTable", fileName = "FieldDataTable")]
public class FieldDataTable : ScriptableObject
{
    public FieldData[] Fields;
}
// ScriptableObject �Ńf�[�^��ۑ��ł���悤��[Serializable]�������`����
[Serializable]
public class FieldData
{
    public int Id;
    public string Name;
    public string SceneName;
    public Sprite Icon;
}