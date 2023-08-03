using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class SettingsBox : MonoBehaviour
{
    public static SettingsBox Instance;

    public static SettingsBox Setup()
    {
        if (Instance == null)
        {
            Instance = Instantiate(Resources.Load(PathPrefab.SETTINGS_BOX) as GameObject).GetComponent<SettingsBox>();
        }
        return Instance;
    }

    private float sound
    {
        get => GameController.Instance.userProfile.SoundVolume;
        set => GameController.Instance.userProfile.SoundVolume = value;
    }
    private float music
    {
        get => GameController.Instance.userProfile.MusicVolume;
        set => GameController.Instance.userProfile.MusicVolume = value;
    }
    private bool isVibration
    {
        get => GameController.Instance.userProfile.OnVibration;
        set => GameController.Instance.userProfile.OnVibration = value;
    }

    [SerializeField] private Slider soundSlider;
    [SerializeField] private TextMeshProUGUI soundPercentTxt;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private TextMeshProUGUI musicPercentTxt;
    [SerializeField] private Button vibrationBtn;
    [SerializeField] private RectTransform circleVibration;
    [SerializeField] private TextMeshProUGUI vibrationBtnTxt;
    [SerializeField] private Button saveBtn;
    [SerializeField] private Button backBtn;

    public void Show()
    {
        StartShowSound();
        StartShowMusic();
        StartShowVibration();
        saveBtn.onClick.AddListener(Save);
        backBtn.onClick.AddListener(DoOff);
    }

    void StartShowSound()
    {
        soundSlider.value = sound;
        soundPercentTxt.text = (Math.Round(sound, 2) * 100f) + "%";
        soundSlider.onValueChanged.AddListener((float fakeSound) => { SoundChanged(fakeSound); });
    }

    void StartShowMusic()
    {
        musicSlider.value = music;
        musicPercentTxt.text = (Math.Round(music, 2) * 100f) + "%";
        musicSlider.onValueChanged.AddListener((float fakeMusic) => { MusicChanged(fakeMusic); });
    }

    void StartShowVibration()
    {
        if (isVibration)
            VibrationOn();
        else
            VibrationOff();
        vibrationBtn.onClick.AddListener(VibrationChange);
    }

    void SoundChanged(float soundVal)
    {
        soundPercentTxt.text = (Math.Round(soundVal, 2) * 100f) + "%";
    }

    void MusicChanged(float musicVal)
    {
        musicPercentTxt.text = (Math.Round(musicVal, 2) * 100f) + "%";
    }

    void VibrationChange()
    {
        if (isVibration)
        {
            isVibration = false;
            VibrationOff();
        }
        else
        {
            isVibration = true;
            VibrationOn();
        }
    }

    void VibrationOn()
    {
        circleVibration.DOAnchorPos(new Vector2(70f, circleVibration.anchoredPosition.y), 1f);
        vibrationBtnTxt.text = "On";
        vibrationBtn.image.color = Color.green;
    }

    void VibrationOff()
    {
        circleVibration.DOAnchorPos(new Vector2(-70f, circleVibration.anchoredPosition.y), 1f);
        vibrationBtnTxt.text = "Off";
        vibrationBtn.image.color = Color.red;
    }

    void Save()
    {
        sound = soundSlider.value;
        music = musicSlider.value;
        isVibration = isVibration;
        PlayerPrefs.Save();
        GameController.Instance.musicManager.InitState();
        DoOff();
    }

    void DoOff()
    {
        Destroy(this.gameObject);
    }
}
