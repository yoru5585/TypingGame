using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScene_s : MonoBehaviour
{
    //�V�[���J�ڗp

    public void OnSceneMoved(string nextSceneName)
    {
        FadeManager.Instance.LoadScene(nextSceneName, 0.5f);
    }
}
