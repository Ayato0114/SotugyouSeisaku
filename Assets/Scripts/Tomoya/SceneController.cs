using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [Header("シーンの名前([file->build settings...]で名前を確認してください)")]
    [SerializeField]
    string SceneName;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneName , LoadSceneMode.Single);
        }
    }
}
