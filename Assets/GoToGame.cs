using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class LoadingScreen : MonoBehaviour
{
    public TMP_Text progressText;
    public GameObject TV;
    public GameObject canvas;
    public float waitTime;
    bool isPressed = false;

    public void Start()
    {
        Invoke("sdarde",waitTime);
    }

    private void sdarde()
    {
        TV.SetActive(true);
        canvas.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && isPressed == false)
        {
            StartCoroutine(LoadSceneAsync("SampleScene"));
            isPressed = true;
        }

    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        // Asenkron olarak sahne yüklenmesini başlat
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        // Sahne yüklenirken devam eden sahneyi durdur
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            // İlerleme çubuğunu ve metni güncelle
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            progressText.text = $"{(progress * 100):0}%";

            // Yükleme tamamlandığında sahneye geçiş yap
            if (operation.progress >= 0.9f)
            {
                progressText.text = "ANLAYANA";
                yield return new WaitForSeconds(1f);
                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}