using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputText_s : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI InputText;
    [SerializeField] TextMeshProUGUI ThemeText;
    [SerializeField] TextMeshProUGUI GrayText;
    char[] split;
    int index = 0;
    bool IsEnd;

    public void SetThemeText(string str)
    {
        ThemeText.text = str;
        GrayText.text = str;
        InputText.text = "";
        split = str.ToCharArray();
        Debug.Log(split[0]);
    }

    public bool GetIsEnd()
    {
        return IsEnd;
    }

    public void SetIsEnd(bool b)
    {
        IsEnd = b;
    }

    public void CheckCorrect()
    {
        string tmp = DownKeyCheck();
        if (tmp == null) { return; }

        if (split[index].ToString().Equals(tmp))
        {
            //Debug.Log("correct");
            InputText.text += tmp;
            index++;
        }

        if (index >= split.Length)
        {
            index = 0;
            IsEnd = true;
        }
    }

    string DownKeyCheck()
    {
        if (Input.anyKeyDown)
        {
            foreach (KeyCode code in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(code))
                {
                    //ˆ—‚ğ‘‚­
                    Debug.Log(code.ToString().ToLower());
                    return code.ToString().ToLower();
                }
            }
        }

        return null;
    }
}
