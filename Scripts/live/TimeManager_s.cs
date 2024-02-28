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
        time = value; //�ő�b�����Z�b�g
    }

    public void AddTime(float value)
    {
        time += value; //�b���𑫂�
    }

    public void SetTime(float value)
    {
        time = value; //�b�����Z�b�g
    }

    public void SetEndAction(Action action)
    {
        this.action = action; //���ԏI�����ɍs������
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
