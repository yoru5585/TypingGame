using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_s : MonoBehaviour
{
    [SerializeField] GameObject typingBG;
    [SerializeField] GameObject resultBG;
    [SerializeField] GameObject menuButton;
    [SerializeField] PlayerInfo_s playerInfo;
    List<string[]> ThemeStr = new List<string[]>();
    InputText_s InputText;
    LoadTextData_s loadTextData;
    PointManager_s pointManager;
    TimeManager_s timeManager;
    ResultManager_s resultManager;
    int index = 1;
    bool IsStop = false;
    // Start is called before the first frame update
    void Start()
    {
        InputText = GetComponent<InputText_s>();
        loadTextData = GetComponent<LoadTextData_s>();
        pointManager = GetComponent<PointManager_s>();
        timeManager = GetComponent<TimeManager_s>();
        resultManager = GetComponent<ResultManager_s>();

        //�^�C�s���O�e�L�X�g���Z�b�g
        loadTextData.ListClear();
        loadTextData.OnRead("Excel/ThemeTextData");
        ThemeStr = loadTextData.GetcsvData();

        //�����l���Z�b�g
        InputText.SetThemeText(ThemeStr[index]);
        pointManager.SetMaxValue(1000);
        timeManager.SetMaxTime(99);
        timeManager.SetEndAction(ShowResult);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsStop)
        {
            //�^�C�s���O�I���@�������́@�Q�[����~
            return;
        }

        if (Input.GetKeyDown(KeyCode.F2)) //F2�ŋ����I�ɕb����1�ɂ���
        {
            timeManager.SetTime(1);
        }

        if (InputText.GetIsEnd() || Input.GetKeyDown(KeyCode.F1)) //F1�ŋ����I�Ɏ��̖��ցi�f�o�b�O�p�j
        {
            //��̕��̓N���A
            index++;
            if (index >= ThemeStr.Count)
            {
                index = 1;
            }
            pointManager.AddPoint(100);
            timeManager.AddTime(2);
            InputText.SetThemeText(ThemeStr[index]);
            InputText.SetIsEnd(false);
            return;
            
        }

        InputText.CheckCorrect(OnMissTyping, OnCorrectTyping);
        timeManager.TimeCount();
    }

    void OnMissTyping()
    {
        //�~�X�������ɍs������
        pointManager.AddPoint(-10);
        timeManager.AddTime(-2);
    }

    void OnCorrectTyping()
    {
        //�^�C�s���O�������i�P�����j�ɍs������
        pointManager.AddPoint(10);
    }

    void ShowResult()
    {
        //���U���g�\�����ɍs������
        typingBG.SetActive(false);
        resultBG.SetActive(true);
        menuButton.SetActive(false);
        resultManager.ShowPoint(pointManager.GetPoint());
        playerInfo.gatyaPoint += pointManager.GetPoint();
        IsStop = true;
    }

    public void SetIsStop(bool b)
    {
        IsStop = b;
    }
}
