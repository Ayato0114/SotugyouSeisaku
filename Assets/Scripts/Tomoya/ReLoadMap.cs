using UnityEngine;
using UnityEngine.SceneManagement;

public class ReLoadMap : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        //Playerタグの付いているオブジェクトが乗ったら
        if (collider.tag.Contains("Player"))
        {
            SceneManager.LoadScene("Map", LoadSceneMode.Single);
        }
    }
}
