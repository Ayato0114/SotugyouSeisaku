using UnityEngine;
using UnityEngine.SceneManagement;

public class ReLoadMap : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        //Player�^�O�̕t���Ă���I�u�W�F�N�g���������
        if (collider.tag.Contains("Player"))
        {
            SceneManager.LoadScene("Map", LoadSceneMode.Single);
        }
    }
}
