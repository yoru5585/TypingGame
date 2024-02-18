using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScene_s : MonoBehaviour
{
    //シーン遷移用

    public void OnSceneMoved(string nextSceneName)
    {
        FadeManager.Instance.LoadScene(nextSceneName, 0.5f);
    }
}
