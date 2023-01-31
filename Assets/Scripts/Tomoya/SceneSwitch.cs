using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    //Exitに到達したかどうか
    private bool exitFlag = false;

    //Exitタイルに乗った時に呼び出される関数
    private void OnTriggerEnter2D(Collider2D collider)
    {
        //まだ到達してない
        if (!exitFlag)
        {
            //Playerタグの付いているオブジェクトが乗ったら
            if (collider.tag.Contains("Player"))
            {
                //何度もフラグが立たないようにする
                exitFlag = true;

            }
        }
    }
}
