using System;
using UnityEngine;

[CreateAssetMenu(menuName = "RandomLabyrinth/FieldDataTable", fileName = "FieldDataTable")]
public class FieldDataTable : ScriptableObject
{
    public FieldData[] Fields;
}
// ScriptableObject でデータを保存できるように[Serializable]属性を定義する
[Serializable]
public class FieldData
{
    public int Id;
    public string Name;
    public string SceneName;
    public Sprite Icon;
}