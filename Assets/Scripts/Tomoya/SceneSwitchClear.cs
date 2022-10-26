using UnityEngine;

public class SceneSwitchClear : MonoBehaviour
{
    //Exitに到達したかどうか
    private bool exitFlag = false;

    //Exitタイルに乗った時に呼び出される関数
    private void OnTrggerEnter2D(Collider2D other)
    {
        //まだ到達してない
        if(!exitFlag)
        {
            //Playerタグの付いているオブジェクトが乗ったら
            if(other.tag.Contains("Player"))
            {
                exitFlag = true;
            }
        }
    }


}
