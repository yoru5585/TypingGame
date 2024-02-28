using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultManager_s : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI resultPointText;
    public void ShowPoint(int point)
    {
        resultPointText.text = point.ToString("N0");
    }
}
