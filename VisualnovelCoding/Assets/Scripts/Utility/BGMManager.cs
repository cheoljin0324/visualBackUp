using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public List<AudioBGM> audioBGMArr;
}

[System.Serializable]
public struct AudioBGM
{
    [Header("����� Ŭ��")]
    public AudioClip bgmClip;
    [Header("����� ���̵�")]
    public string audioID;
}
