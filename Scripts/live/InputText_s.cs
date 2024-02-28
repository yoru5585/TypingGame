using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputText_s : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI InputText;
    [SerializeField] TextMeshProUGUI ThemeText;
    [SerializeField] TextMeshProUGUI HiraganaText;
    string str;
    char[] split;
    int index;
    bool IsEnd;

    public void SetThemeText(string [] ary)
    {
        ThemeText.text = ary[0];
        HiraganaText.text = ary[1];
        str = ary[2].Replace(" ", ",");
        InputText.text = str;
        split = str.ToCharArray();
        index = 0;
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

    public void CheckCorrect(Action missAction, Action correctAction)
    {
        char tmp = DownKeyCheck();
        if (tmp == '\0') { return; }

        if (split[index].Equals(tmp))
        {
            //正解
            //Debug.Log("correct");
            //InputText.text += tmp;
            correctAction.Invoke();
            InputText.text = "<style=typed>" 
                + str.Substring(0, index + 1) + "</style><style=untyped>" 
                + str.Substring(index + 1) + "</style>"; //入力した文字を表示
            index++;
        }
        else
        {
            //ミス
            missAction.Invoke();
        }

        if (index >= split.Length)
        {
            //一つの文章のタイピングが終了
            index = 0;
            IsEnd = true;
        }
    }

    char DownKeyCheck()
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                foreach (KeyCode code in Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKeyDown(code))
                    {
                        //シフトの処理
                        Debug.Log(code.ToString().ToLower());
                        return GetCharFromKeyCodeOnShift(code);
                    }
                }
            }

            foreach (KeyCode code in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(code))
                {
                    //それ以外の処理
                    Debug.Log(code.ToString().ToLower());
                    return GetCharFromKeyCode(code);
                }
            }
        }

        return '\0';
    }

    char GetCharFromKeyCodeOnShift(KeyCode keyCode)
    {
        switch (keyCode)
        {
            case KeyCode.A:
                return 'A';
            case KeyCode.B:
                return 'B';
            case KeyCode.C:
                return 'C';
            case KeyCode.D:
                return 'D';
            case KeyCode.E:
                return 'E';
            case KeyCode.F:
                return 'F';
            case KeyCode.G:
                return 'G';
            case KeyCode.H:
                return 'H';
            case KeyCode.I:
                return 'I';
            case KeyCode.J:
                return 'J';
            case KeyCode.K:
                return 'K';
            case KeyCode.L:
                return 'L';
            case KeyCode.M:
                return 'M';
            case KeyCode.N:
                return 'N';
            case KeyCode.O:
                return 'O';
            case KeyCode.P:
                return 'P';
            case KeyCode.Q:
                return 'Q';
            case KeyCode.R:
                return 'R';
            case KeyCode.S:
                return 'S';
            case KeyCode.T:
                return 'T';
            case KeyCode.U:
                return 'U';
            case KeyCode.V:
                return 'V';
            case KeyCode.W:
                return 'W';
            case KeyCode.X:
                return 'X';
            case KeyCode.Y:
                return 'Y';
            case KeyCode.Z:
                return 'Z';
            case KeyCode.Alpha1:
                return '!';
            case KeyCode.Alpha2:
                return '"';
            case KeyCode.Alpha3:
                return '#';
            case KeyCode.Alpha4:
                return '$';
            case KeyCode.Alpha5:
                return '%';
            case KeyCode.Alpha6:
                return '&';
            case KeyCode.Alpha8:
                return '(';
            case KeyCode.Alpha9:
                return ')';
            case KeyCode.Minus:
                return '=';
            case KeyCode.Caret:
                return '~';
            case KeyCode.Slash:
                return '?';
            default: //上記以外のキーが押された場合は「null文字」を返す。
                return '\0';
        }
    }

    char GetCharFromKeyCode(KeyCode keyCode)
    {
        switch (keyCode)
        {
            case KeyCode.A:
                return 'a';
            case KeyCode.B:
                return 'b';
            case KeyCode.C:
                return 'c';
            case KeyCode.D:
                return 'd';
            case KeyCode.E:
                return 'e';
            case KeyCode.F:
                return 'f';
            case KeyCode.G:
                return 'g';
            case KeyCode.H:
                return 'h';
            case KeyCode.I:
                return 'i';
            case KeyCode.J:
                return 'j';
            case KeyCode.K:
                return 'k';
            case KeyCode.L:
                return 'l';
            case KeyCode.M:
                return 'm';
            case KeyCode.N:
                return 'n';
            case KeyCode.O:
                return 'o';
            case KeyCode.P:
                return 'p';
            case KeyCode.Q:
                return 'q';
            case KeyCode.R:
                return 'r';
            case KeyCode.S:
                return 's';
            case KeyCode.T:
                return 't';
            case KeyCode.U:
                return 'u';
            case KeyCode.V:
                return 'v';
            case KeyCode.W:
                return 'w';
            case KeyCode.X:
                return 'x';
            case KeyCode.Y:
                return 'y';
            case KeyCode.Z:
                return 'z';
            case KeyCode.Alpha0:
                return '0';
            case KeyCode.Alpha1:
                return '1';
            case KeyCode.Alpha2:
                return '2';
            case KeyCode.Alpha3:
                return '3';
            case KeyCode.Alpha4:
                return '4';
            case KeyCode.Alpha5:
                return '5';
            case KeyCode.Alpha6:
                return '6';
            case KeyCode.Alpha7:
                return '7';
            case KeyCode.Alpha8:
                return '8';
            case KeyCode.Alpha9:
                return '9';
            case KeyCode.Minus:
                return '-';
            case KeyCode.Caret:
                return '^';
            case KeyCode.Backslash:
                return '\\';
            case KeyCode.At:
                return '@';
            case KeyCode.LeftBracket:
                return '[';
            case KeyCode.Semicolon:
                return ';';
            case KeyCode.Colon:
                return ':';
            case KeyCode.RightBracket:
                return ']';
            case KeyCode.Comma:
                return ',';
            case KeyCode.Period:
                return '.';
            case KeyCode.Slash:
                return '/';
            case KeyCode.Underscore:
                return '_';
            case KeyCode.Backspace:
                return '\b';
            case KeyCode.Return:
                return '\r';
            case KeyCode.Space:
                return ' ';
            default: //上記以外のキーが押された場合は「null文字」を返す。
                return '\0';
        }
    }
}
