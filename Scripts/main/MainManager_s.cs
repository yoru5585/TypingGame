using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainManager_s : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI gatyaPointText;
    [SerializeField] Button saveButton;
    [SerializeField] Button loadButton;
    [SerializeField] Button deleteButton;
    [SerializeField] Button gatyaButton;
    [SerializeField] Button charaButton;
    [SerializeField] Button HomeButton;
    [SerializeField] GameObject gatya;
    [SerializeField] GameObject charaSelect;
    [SerializeField] PlayerInfo_s playerInfo;
    // Start is called before the first frame update
    void Start()
    {
        gatyaPointText.text = "ÉKÉ`ÉÉPÅF" + playerInfo.gatyaPoint.ToString("N0");
        SetButtonListener();
    }

    void SetButtonListener()
    {
        SaveManager_s saveManager = GameObject.FindGameObjectWithTag("SaveManager").GetComponent<SaveManager_s>();
        saveButton.onClick.AddListener(() => { ConfirmWindow_s.SetWindow("ConWinDatas/ConWinData1"); saveManager.Save(); });
        loadButton.onClick.AddListener(() => { ConfirmWindow_s.SetWindow("ConWinDatas/ConWinData2"); saveManager.Load(); });
        deleteButton.onClick.AddListener(
            () => ConfirmWindow_s.SetWindow("ConWinDatas/ConWinData3",
                () => { ConfirmWindow_s.SetWindow("ConWinDatas/ConWinData5"); saveManager.DeleteData(); }));

        gatyaButton.onClick.AddListener(() => SetActiveBG(true, false));
        charaButton.onClick.AddListener(() => SetActiveBG(false, true));
        HomeButton.onClick.AddListener(() => SetActiveBG(false, false));
    }

    void SetActiveBG(bool gatyaFlag, bool charaFlag)
    {
        gatya.SetActive(gatyaFlag);
        charaSelect.SetActive(charaFlag);
    }
}
