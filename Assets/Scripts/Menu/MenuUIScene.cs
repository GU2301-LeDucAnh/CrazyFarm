using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUIScene : MonoBehaviour
{
    public Button btnPlay;
    public Button btnSetting;
    public Button btnExit;

    // Start is called before the first frame update
    public void Init()
    {
        btnPlay.onClick.AddListener(ChangeToSceneGameplay);
        btnSetting.onClick.AddListener(SettingSetup);
        btnExit.onClick.AddListener(OutGame);
    }

    void SettingSetup()
    {
        GameController.Instance.musicManager.PlayOneShot(UIMusic.UI_BUTTON_2);
        SettingsBox.Setup().Show();
    }

    void ChangeToSceneGameplay()
    {
        GameController.Instance.musicManager.PlayOneShot(UIMusic.UI_BUTTON_1);
        GameController.Instance.LoadScene(SceneName.GAME_PLAY);
    }

    void OutGame()
    {
        GameController.Instance.musicManager.PlayOneShot(UIMusic.UI_BUTTON_3);
        Application.Quit();
    }
}
