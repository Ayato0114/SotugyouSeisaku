using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Player��Exit�ɏ������
        if (collision.tag == "Exit")
        {
            //BoarManager boarManager = new BoarManager();
            //if (boarManager.GetSetProperty == true)
            //{
            //    boarManager.GetSetProperty = false;
            //}
            Invoke("Restart", 0.5f);
        }


    }

    public void Restart()
    {
       
        SceneManager.LoadScene(3);
    }

}
