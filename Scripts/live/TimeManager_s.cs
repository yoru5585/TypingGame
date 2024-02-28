using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TimeManager_s : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeText;
    float time;
    Action action;

    public void SetMaxTime(float value)
    {
        time = value; //最大秒数をセット
    }

    public void AddTime(float value)
    {
        time += value; //秒数を足す
    }

    public void SetTime(float value)
    {
        time = value; //秒数をセット
    }

    public void SetEndAction(Action action)
    {
        this.action = action; //時間終了時に行う処理
    }

    public void TimeCount()
    {
        time -= Time.deltaTime;
        timeText.text = ((int)time).ToString();
        if (time <= 0)
        {
            Debug.Log("LiveEnd");
            action.Invoke();
        }
    }
}
