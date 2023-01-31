using UnityEngine;
public class Tomoya_GameManager : MonoBehaviour
{
    // ゲーム開始時直後のシーン読み込み前に呼ばれるようにする属性を指定
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void InitializeBeforeSceneLoad()
    {
        // Resources フォルダ内の GameManager プレハブを読み込み
        var gameManagerPrefab = Resources.Load<GameManager>("   ");
        // ゲーム中に常に存在するオブジェクトを生成
        var gameManager = Instantiate(gameManagerPrefab);
        // シーンの変更時にも破棄されないようにする
        DontDestroyOnLoad(gameManager);
    }
}