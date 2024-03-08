using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class AsyncLoader : MonoBehaviour
{
    [Header("menu screens")]
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private GameObject mainMenu;

    [Header("Slider")]
    [SerializeField] private Image loadingSlider;
    [SerializeField] private TextMeshProUGUI loadingText;

    private bool loadBool;
    private float loadTime;

    public void LoadLevelBtn(string levelToLoad)
    {
        mainMenu.SetActive(false);
        loadingScreen.SetActive(true);

        //Run the A sync
        loadTime = 0.5f;
        loadBool = true;
        StartCoroutine(LoadLevelASync(levelToLoad));

    }

    IEnumerator LoadLevelASync(string levelToLoad)
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(levelToLoad);
        while(!loadOperation.isDone)
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
