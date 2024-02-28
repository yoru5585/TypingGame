using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.EventSystems;

public class ChangeText_s : MonoBehaviour
{
    LoadTextData_s loadTextData;
    TextLog_s textLog;
    [SerializeField] PlayerInfo_s playerInfo;
    List<string[]> textData = new List<string[]>();

    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI mainText;

    float timeInterval;
    float timeCount;
    int visibleLen;
    int sentenceNum;
    int state;

    Action endEvent;
    bool IsStop = false;
    bool IsAuto = false;

    // Start is called before the first frame update
    void Start()
    {
        loadTextData = GetComponent<LoadTextData_s>();
        textLog = GetComponent<TextLog_s>();
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsStop)
        {
            return;
        }

        switch (state)
        {
            case 0:
                nameText.text = textData[sentenceNum][0] + "�F";
                state++;
                break;
            case 1:
                if (visibleLen >= textData[sentenceNum][1].Length)
                {
                    textLog.AddList(textData[sentenceNum]);
                    state++;
                    break;
                }

                timeCount += Time.deltaTime;

                if (Controll_s.GetMouseButtonDown())
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
                //�l��������
                if (Controll_s.GetMouseButtonDown() || IsAuto)
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

    void Init()
    {
        timeInterval = 0.1f;
        timeCount = 0;
        visibleLen = 0;
        sentenceNum = 1;
        state = 99;
        IsAuto = false;
        textData.Clear();
        nameText.text = "";
        mainText.text = "";
    }

    public void StartMessage(string pass, Action endEvent)
    {
        this.endEvent = endEvent; //�S�Ẵ��b�Z�[�W��\����Ɏ��s
        loadTextData.ListClear(); //���X�g���N���A
        loadTextData.OnRead(pass); //�e�L�X�g�f�[�^�����[�h
        textData = loadTextData.GetcsvData(); //�e�L�X�g�f�[�^���擾
        foreach (string[] str in textData)
        {
            str[0] = str[0].Replace("#name#", playerInfo.playerName); //�v���C���[�l�[���ɕϊ�
            str[1] = str[1].Replace("#name#", playerInfo.playerName);
        }
        transform.GetChild(0).gameObject.SetActive(true); //UI��\��
        state = 0; //���b�Z�[�W����J�n
    }

    public void SetIsStop(bool flag)
    {
        IsStop = flag;
    }

    public  void SetIsAuto(bool flag)
    {
        IsAuto = flag;
    }

    public float GetSetTimeInterval
    {
        get{ return timeInterval; }
        set{ timeInterval = value; }
    }
}
