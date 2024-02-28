using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Chara")]
public class CharaInfo_s : ScriptableObject
{
    [Header("�L�����N�^�[��")] public string charaName; //���O
    [Header("�^�C�v")] public string type; //�^�C�v
    [Header("�m��")] public int sense; //�m��
    [Header("�����^��")] public int mental; //�����^��
    public enum State
    {
        obtained, unacquired, unimplemented
    }
    [SerializeField] [Header("������")] public State state;
}
