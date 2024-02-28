using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextLog_s : MonoBehaviour
{
    //ログ管理スクリプト
    List<string[]> logData = new List<string[]>();
    [SerializeField] Transform content;
    [SerializeField] GameObject textBG;
    [SerializeField] GameObject logBG;
    GameObject originTextObj;
    void Start()
    {
        originTextObj = content.transform.GetChild(0).gameObject;
    }

    public void ShowLog()
    {
        GetComponent<ChangeText_s>().SetIsStop(true);
        textBG.SetActive(false);
        logBG.SetActive(true);

        foreach (string[] ary in logData)
        {
            GameObject obj = Instantiate(originTextObj, Vector3.zero, Quaternion.identity, content);
            originTextObj.GetComponent<TextMeshProUGUI>().text = ary[0] + "：\n" + ary[1];
            originTextObj = obj;
        }
    }

    public void AddList(string[] ary)
    {
        logData.Add(ary);
    }

    public void CloseTab()
    {
        Debug.Log("closetab");
        GetComponent<ChangeText_s>().SetIsStop(false);
        textBG.SetActive(true);
        logBG.SetActive(false);
    }
}
