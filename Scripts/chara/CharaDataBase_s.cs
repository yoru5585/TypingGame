using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CharaDataBase")]
public class CharaDataBase_s : ScriptableObject
{
    public List<CharaInfo_s> charaData = new List<CharaInfo_s>();
}
