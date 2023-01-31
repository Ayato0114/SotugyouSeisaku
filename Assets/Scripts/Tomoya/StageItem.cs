using UnityEngine;
using TMPro;
public class StageItem : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI titleText;
    public void Setup(StageData stageData)
    {
        // クエストタイトル名を設定
        titleText.text = stageData.Name;
    }
}