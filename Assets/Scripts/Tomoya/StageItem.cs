using UnityEngine;
using TMPro;
public class StageItem : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI titleText;
    public void Setup(StageData stageData)
    {
        // �N�G�X�g�^�C�g������ݒ�
        titleText.text = stageData.Name;
    }
}