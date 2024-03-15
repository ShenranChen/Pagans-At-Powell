using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class RestartLoader : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private GameObject gameoverScr;

    [SerializeField] private Image loadingSlider;
    [SerializeField] private TextMeshProUGUI loadingText;

    private bool loadBool;
    private float loadTime;

    public void LoadLevelBtn()
    {
        gameoverScr.SetActive(false);
        loadingScreen.SetActive(true);

        //Run the A sync
        loadTime = 0.5f;
        loadBool = true;

        StartCoroutine(RestartLevelASync());
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    IEnumerator RestartLevelASync()
    {
        //Debug.Log("Time Scale" + Time.timeScale);
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        while (!loadOperation.isDone)
        {
            loadingSlider.fillAmount = loadOperation.progress;
            yield return null;
        }
    }

    private void Update()
    {
        if (loadBool && loadTime <= 0)
        {
            if (loadingText.text == "Loading . . .")
                loadingText.text = "Loading";
            else if (loadingText.text == "Loading")
                loadingText.text = "Loading .";
            else if (loadingText.text == "Loading .")
                loadingText.text = "Loading . .";
            else if (loadingText.text == "Loading . .")
                loadingText.text = "Loading . . .";
            loadTime = 1f;
        }
        if (loadTime > 0)
        {
            loadTime -= Time.deltaTime;
        }
    }
}
