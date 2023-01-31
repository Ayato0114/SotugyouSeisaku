using UnityEngine;
using UnityEngine.SceneManagement;

public class ReLoadMap : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collider)
    {
        
        //Player�^�O�̕t���Ă���I�u�W�F�N�g���������
        if (collider.tag.Contains("Player"))
        {
            if (GameManager.mapCount > 3)
            {
                SceneManager.LoadScene("Clear", LoadSceneMode.Single);

            }
            else
            {
                SceneManager.LoadScene("Map", LoadSceneMode.Single);
            }
        }
    }
}
