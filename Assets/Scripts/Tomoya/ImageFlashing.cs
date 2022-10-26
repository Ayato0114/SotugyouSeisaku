using UnityEngine;
using UnityEngine.UI;

public class ImageFlashing : MonoBehaviour
{
    [SerializeField]
    Image image;


    [Header("1���[�v�̒���(�b�P��)")]
    [SerializeField]
    [Range(0.1f, 10.0f)]
    float duration = 1.0f;

    //���[�v�J�n���̐F��0�`255�܂ł̐����Ŏw��B
    //���摜�����̏ꍇ�́A�w�肵���F�ɂȂ�B�h�b�g�G���̏ꍇ�́A���F���w�肷��ƌ��摜�ւ̉e���Ȃ��B�A���t�@�l�[���Ŋ��S�ɓ����B
    [Header("���[�v�J�n���̐F")]
    [SerializeField]
    Color32 startColor = new Color32(255, 255, 255, 255);

    [Header("���[�v�I�����̐F")]
    [SerializeField]
    Color32 endColor = new Color32(255, 255, 255, 64);

    void Update()
    {
        image.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time / duration, 1.0f));
    }

}
