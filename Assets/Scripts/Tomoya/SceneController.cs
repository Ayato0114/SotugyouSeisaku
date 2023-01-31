using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [Header("�V�[���̖��O([file->build settings...]�Ŗ��O���m�F���Ă�������)")]
    [SerializeField]
    string SceneName;

    [Header("�j���Ώ�")]
    [SerializeField]
    GameObject[] deleteObj;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Map", LoadSceneMode.Single);
        }
    }
}
