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
    // Start is called before the first frame update
    void Start()
    {
        talk = GameObject.Find("Talk");
        inputName = GameObject.Find("InputName").transform.GetChild(0).gameObject;
        selectChara = GameObject.Find("SelectChara").transform.GetChild(0).gameObject;
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
        GameObject.Find("PlayerData").GetComponent<PlayerInfo_s>().playerName = name;

        inputName.SetActive(false);
        talk.GetComponent<ChangeText_s>().StartMessage("Excel/StartupTextData", () => selectChara.SetActive(true));
    }

    public void OnCharaSelected()
    {
        selectChara.SetActive(false);
        talk.GetComponent<ChangeText_s>().StartMessage("Excel/StartupTextData2", () => GetComponent<MoveScene_s>().OnSceneMoved("MainScene"));
    }
}
