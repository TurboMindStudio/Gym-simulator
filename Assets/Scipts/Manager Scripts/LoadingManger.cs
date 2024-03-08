using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class LoadingManger : MonoBehaviour
{
    public static LoadingManger instance;

    public Slider slider;
    public TextMeshProUGUI progressText;
    public GameObject LoadingPanel;
    private void Awake()
    {
        instance = this;
        LoadingPanel.SetActive(false);
    }

    public void LoadSceneAsync(string sceneName)
    {
        StartCoroutine(LoadSceneCoroutine(sceneName));
        LoadingPanel.SetActive(true);
    }

    public IEnumerator LoadSceneCoroutine(string sceneName)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncOperation.isDone)
        {
            float progress = Mathf.Clamp01(asyncOperation.progress / 0.9f); // 0.9 is the completion value
            slider.value = progress;
            progressText.text = (progress * 100f).ToString("F0") + "%";

            yield return null; // Wait for the next frame
        }
    }
}


