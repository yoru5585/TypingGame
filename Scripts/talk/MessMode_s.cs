using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessMode_s : MonoBehaviour
{
    ChangeText_s changeText;
    bool fastModeFlag = true;
    //二倍速、自動モード管理
    void Start()
    {
        changeText = GetComponent<ChangeText_s>();
    }
    
    public void FastMode()
    {
        if (fastModeFlag)
        {
            fastModeFlag = false;
            changeText.GetSetTimeInterval = 0.01f;
        }
        else
        {
            fastModeFlag = true;
            changeText.GetSetTimeInterval = 0.1f;
        }
        
    }

    public void AutoMode()
    {
        changeText.SetIsAuto(true);
    }
}
