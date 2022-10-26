using UnityEngine;
using UnityEngine.UI;

public class ImageFlashing : MonoBehaviour
{
    [SerializeField]
    Image image;


    [Header("1ループの長さ(秒単位)")]
    [SerializeField]
    [Range(0.1f, 10.0f)]
    float duration = 1.0f;

    //ループ開始時の色を0～255までの整数で指定。
    //元画像が白の場合は、指定した色になる。ドット絵等の場合は、白色を指定すると元画像への影響なし。アルファ値ゼロで完全に透明。
    [Header("ループ開始時の色")]
    [SerializeField]
    Color32 startColor = new Color32(255, 255, 255, 255);

    [Header("ループ終了時の色")]
    [SerializeField]
    Color32 endColor = new Color32(255, 255, 255, 64);

    void Update()
    {
        image.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time / duration, 1.0f));
    }

}
