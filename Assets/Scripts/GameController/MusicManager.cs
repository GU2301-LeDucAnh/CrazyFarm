using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BackgroundMusic
{
    NONE,
    BACK_GROUND_1,
    BACK_GROUND_2,
    BACK_GROUND_3
}

public enum UIMusic
{
    NONE = 0,

    ACTION_WALK,
    ACTION_PLANT,

    UI_BUTTON_1,
    UI_BUTTON_2,
    UI_BUTTON_3,
}

[Serializable]
public class BackgroundMusicClip
{
    public BackgroundMusic bgMusicType;
    public AudioClip audioClip;
}

[Serializable]
public class UIMusicClip
{
    public UIMusic uiMusicType;
    public AudioClip audioClip;
}

public class MusicManager : MonoBehaviour
{
    public AudioSource m_MusicSource;
    public AudioSource m_SoundSource;

    public List<BackgroundMusicClip> musicClip;
    public List<UIMusicClip> soundClip;

    public void Init()
    {
        PlayBG(BackgroundMusic.BACK_GROUND_1);
    }

    public void PlayBG(BackgroundMusic backgroundMusic)
    {
        var clipBG = musicClip.Find(x => x.bgMusicType == backgroundMusic);
        m_MusicSource.clip = clipBG.audioClip;
        m_MusicSource.volume = GameController.Instance.userProfile.MusicVolume;
        m_MusicSource.loop = true;
        m_MusicSource.Play();
    }

    public void PlayOneShot(UIMusic uIMusic)
    {
        var clipSound = soundClip.Find(x => x.uiMusicType == uIMusic);
        m_SoundSource.clip = clipSound.audioClip;
        m_SoundSource.volume = GameController.Instance.userProfile.SoundVolume;
        m_SoundSource.loop = false;
        m_SoundSource.Play();
    }

    public void InitState()
    {
        m_MusicSource.volume = GameController.Instance.userProfile.MusicVolume;
        m_SoundSource.volume = GameController.Instance.userProfile.SoundVolume;
    }
}
