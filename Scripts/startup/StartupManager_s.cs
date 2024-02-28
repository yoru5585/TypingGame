using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartupManager_s : MonoBehaviour
{
    GameObject talk;
    GameObject inputName;
    GameObject selectChara;

    [SerializeField] PlayerInfo_s playerInfo;
    SaveManager_s saveManager;
    // Start is called before the first frame update
    void Start()
    {
        talk = GameObject.Find("Talk");
        inputName = GameObject.Find("InputName").transform.GetChild(0).gameObject;
        selectChara = GameObject.Find("SelectChara").transform.GetChild(0).gameObject;

        saveManager = GameObject.FindGameObjectWithTag("SaveManager").GetComponent<SaveManager_s>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPlayerName()
    {
        TMP_InputField inputField = GameObject.Find("InputField").GetComponent<TMP_InputField>();
        string name = inputField.text;
        Debug.Log("プレイヤーの名前：" + name);
        playerInfo.playerName = name;
        saveManager.Save();

        inputName.SetActive(false);
        talk.GetComponent<ChangeText_s>().StartMessage("Excel/StartupTextData", () => selectChara.SetActive(true));
    }

    public void OnCharaSelected()
    {
        selectChara.SetActive(false);
        talk.GetComponent<ChangeText_s>().StartMessage("Excel/StartupTextData2", () => GetComponent<MoveScene_s>().OnSceneMoved("MainScene"));
    }
}
