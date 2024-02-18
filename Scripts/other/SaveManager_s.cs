using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveManager_s : MonoBehaviour
{
    string filePath;
    SaveData_s save;
    PlayerInfo_s playerInfo;

    private void Awake()
    {
        filePath = Application.persistentDataPath + "/" + ".savedata.json";
        Debug.Log(filePath);
        save = new SaveData_s();
        playerInfo = GameObject.Find("PlayerData").GetComponent<PlayerInfo_s>();
    }

    public void Load()
    {
        if (File.Exists(filePath))
        {
            StreamReader streamReader;
            streamReader = new StreamReader(filePath);
            string data = streamReader.ReadToEnd();
            streamReader.Close();
            save = JsonUtility.FromJson<SaveData_s>(data);

            GetData();
            Debug.Log("���[�h���܂����B");
            return;
        }

        Debug.Log("�f�[�^���Ȃ��̂Ń��[�h�ł��܂���ł����B");
    }

    public void Save()
    {
        SetData();
        string json = JsonUtility.ToJson(save);
        StreamWriter streamWriter = new StreamWriter(filePath);
        streamWriter.Write(json); streamWriter.Flush();
        streamWriter.Close();
        Debug.Log("�Z�[�u���܂����B");
    }

    public void SetData()
    {
        save.playerName = playerInfo.playerName;
    }

    public void GetData()
    {
        playerInfo.playerName = save.playerName;
    }

    public void DeleteData()
    {
        File.Delete(filePath);
    }

    public bool CheckFileExists()
    {
        return File.Exists(filePath);
    }
}
