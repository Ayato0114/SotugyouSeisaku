using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    // Update()���Ă΂��O�Ɉ�x�����Ă΂��֐�
    void Start()
    {
        // QualitySettings.vSyncCount = 0;
        // Application.targetFrameRate = 10;
    }

    // ���t���[���Ă΂��֐�
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); // X
        float vertical = Input.GetAxis("Vertical");     // Y
        Debug.Log(horizontal); // �������͒l���R���\�[���E�C���h�E�֏o��
        Vector2 position = transform.position;
        position.x = position.x + 0.6f * horizontal * Time.deltaTime;
        position.y = position.y + 0.6f * vertical * Time.deltaTime;
        transform.position = position;
    }
}
