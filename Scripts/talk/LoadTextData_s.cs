using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoadTextData_s : MonoBehaviour
{
    private TextAsset _csvFile;   //CSVファイル

    private List<string[]> _csvData = new List<string[]>();  //CSVファイルの中身を入れるリスト

    public void OnRead(string pass)
    {
        _csvFile = Resources.Load(pass) as TextAsset;   //Resourceにある指定のパスのCSVファイルを格納
        StringReader reader = new StringReader(_csvFile.text);      //TextAssetをStringReaderに変換

        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine();   //１行ずつ読む 
            _csvData.Add(line.Split(','));    //読みこんだDataをリストにAddする
        }

        for (int i = 1; i < _csvData.Count; i++)
        {
            foreach (string str in _csvData[i])
            {
                Debug.Log(str); //テスト
            }
        }
        Debug.Log("END_read");
    }

    public List<string[]> GetcsvData()
    {
        return _csvData;
    }

    public void ListClear()
    {
        _csvData.Clear();
    }
}
