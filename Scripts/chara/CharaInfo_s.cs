using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Chara")]
public class CharaInfo_s : ScriptableObject
{
    [Header("キャラクター名")] public string charaName; //名前
    [Header("タイプ")] public string type; //タイプ
    [Header("ノリ")] public int sense; //ノリ
    [Header("メンタル")] public int mental; //メンタル
    public enum State
    {
        obtained, unacquired, unimplemented
    }
    [SerializeField] [Header("入手状態")] public State state;
}
