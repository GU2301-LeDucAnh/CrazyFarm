using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{
    public TextMeshProUGUI txtLoading;
    public Image bar;
    // Start is called before the first frame update
    void Start()
    {
        bar.fillAmount = 0f;
        StartCoroutine(RunLoading());
        StartCoroutine(LoadingText());
    }

    IEnumerator RunLoading()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneName.MENU_SCENE);

        while (!operation.isDone)
        {
            float progressVal = Mathf.Clamp01(operation.progress / 0.1f);
            bar.fillAmount = progressVal;
            yield return null;
        }
    }

    IEnumerator LoadingText()
    {
        var wait = new WaitForSeconds(1f);
        while (true)
        {
            txtLoading.text = "LOADING .";
            yield return wait;

            txtLoading.text = "LOADING ..";
            yield return wait;

            txtLoading.text = "LOADING ...";
            yield return wait;

        }
    }
}
