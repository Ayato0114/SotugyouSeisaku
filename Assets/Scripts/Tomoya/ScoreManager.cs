using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public EnemyController target;

    private void OnDisable()
    {
        target.OnDestroyed.RemoveAllListeners();
    }
    private void OnEnable()
    {
        target.OnDestroyed.AddListener(() =>
        {
            Debug.Log("target��Destroy����܂���");
            //�����ɏ�����ǉ�
        });
    }
}
