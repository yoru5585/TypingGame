using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartManager_s : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] TextMeshProUGUI playerName;
    [SerializeField] PlayerInfo_s playerInfo;
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.RemoveAllListeners();
        //セーブデータが存在するか確認
        if (GetComponent<SaveManager_s>().CheckFileExists())
        {
            button.onClick.AddListener(() => GetComponent<MoveScene_s>().OnSceneMoved("mainScene"));
            GetComponent<SaveManager_s>().Load();
            playerName.text = playerInfo.playerName;
        }
        else
        {
            button.onClick.AddListener(() => GetComponent<MoveScene_s>().OnSceneMoved("StartupScene"));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
