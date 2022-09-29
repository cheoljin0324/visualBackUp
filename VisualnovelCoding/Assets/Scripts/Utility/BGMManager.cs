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
    [Header("오디오 클립")]
    public AudioClip bgmClip;
    [Header("오디오 아이디")]
    public string audioID;
}
