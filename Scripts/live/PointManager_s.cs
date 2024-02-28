using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PointManager_s : MonoBehaviour
{
    [SerializeField] Slider pointSlider;
    [SerializeField] TextMeshProUGUI pointText;
    int point;

    public void SetMaxValue(int maxValue)
    {
        pointSlider.maxValue = maxValue;
    }

    public void AddPoint(int value = 100)
    {
        point += value;
        if (point <= 0)
        {
            point = 0;
        }
        pointText.text = point.ToString();
        pointSlider.value = point;
    }

    public int GetPoint()
    {
        return point;
    }
}
