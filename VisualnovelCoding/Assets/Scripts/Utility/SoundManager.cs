using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    VoiceManager voiceManager;
    BGMManager bgmManager;
    public AudioSource bgmPlayer;
    public AudioSource voicePlayer;

    private void Awake()
    {
        voiceManager = GetComponent<VoiceManager>();
        bgmManager = GetComponent<BGMManager>();
    }

    public void BGMPlay(string ID)
    {
        for(int i = 0; i<bgmManager.audioBGMArr.Count; i++)
        {
            if(bgmManager.audioBGMArr[i].audioID == ID)
            {
                bgmPlayer.clip = bgmManager.audioBGMArr[i].bgmClip;
            }
        }
        bgmPlayer.loop = true;
        bgmPlayer.Play();


    }

    public void VoicePlay(string voiceID)
    {
        for(int i = 0; i<voiceManager.voiceBGM.Count; i++)
        {
            if(voiceManager.voiceBGM[i].audioID == voiceID) 
            {
                voicePlayer.clip = voiceManager.voiceBGM[i].bgmClip;
            }
        }
        voicePlayer.loop = false;
        voicePlayer.Play();
    }

    public void VoiceStop()
    {
        voicePlayer.Stop();
    }

    public void BGMStop()
    {
        bgmPlayer.Stop();
    }
}
