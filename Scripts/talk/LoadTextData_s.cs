using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoadTextData_s : MonoBehaviour
{
    private TextAsset _csvFile;   //CSV�t�@�C��

    private List<string[]> _csvData = new List<string[]>();  //CSV�t�@�C���̒��g�����郊�X�g

    public void OnRead(string pass)
    {
        _csvFile = Resources.Load(pass) as TextAsset;   //Resource�ɂ���w��̃p�X��CSV�t�@�C�����i�[
        StringReader reader = new StringReader(_csvFile.text);      //TextAsset��StringReader�ɕϊ�

        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine();   //�P�s���ǂ� 
            _csvData.Add(line.Split(','));    //�ǂ݂���Data�����X�g��Add����
        }

        for (int i = 1; i < _csvData.Count; i++)
        {
            Debug.Log(_csvData[i][0]);
            Debug.Log(_csvData[i][1]);
        }
        Debug.Log("END_read");
    }

    public List<string[]> GetcsvData()
    {
        return _csvData;
    }
}
