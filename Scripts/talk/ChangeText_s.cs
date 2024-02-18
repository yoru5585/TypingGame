using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ChangeText_s : MonoBehaviour
{
    LoadTextData_s loadTextData;
    List<string[]> textData = new List<string[]>();

    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI mainText;

    float timeInterval;
    float timeCount;
    int visibleLen;
    int sentenceNum;
    int state;

    Action endEvent;

    // Start is called before the first frame update
    void Start()
    {
        loadTextData = GetComponent<LoadTextData_s>();
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case 0:
                nameText.text = textData[sentenceNum][0];
                state++;
                break;
            case 1:
                if (visibleLen >= textData[sentenceNum][1].Length)
                {
                    state++;
                    break;
                }

                timeCount += Time.deltaTime;

                if (Input.GetMouseButtonDown(0))
                {
                    visibleLen = textData[sentenceNum][1].Length - 1;
                }

                if (timeCount >= timeInterval)
                {
                    timeCount = 0;
                    visibleLen++;
                    mainText.text = textData[sentenceNum][1].Substring(0, visibleLen);
                }
                break;
            case 2:
                //’l‚ð‰Šú‰»
                if (Input.GetMouseButtonDown(0))
                {
                    visibleLen = 0;
                    state = 0;
                    sentenceNum++;
                    if (sentenceNum >= textData.Count)
                    {
                        //**** end ****
                        
                        transform.GetChild(0).gameObject.SetActive(false);
                        endEvent.Invoke();
                        Init();
                        Debug.Log("textEND");

                        //**** end ****
                    }
                }
                break;
            default:
                break;

        }
    }

    public void StartMessage(string pass, Action endEvent)
    {
        this.endEvent = endEvent;
        loadTextData.OnRead(pass);
        textData = loadTextData.GetcsvData();
        transform.GetChild(0).gameObject.SetActive(true);
        state = 0;
    }

    void Init()
    {
        timeInterval = 0.1f;
        timeCount = 0;
        visibleLen = 0;
        sentenceNum = 1;
        state = 99;
        textData.Clear();
        nameText.text = "";
        mainText.text = "";
    }
}
