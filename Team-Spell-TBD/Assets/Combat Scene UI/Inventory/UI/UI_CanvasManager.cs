using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_CanvasManager : MonoBehaviour
{
    [SerializeField] private GameObject hudParent;
    [SerializeField] private GameObject settingParent;
    [SerializeField] private GameObject gameover;
    [SerializeField] private GameObject loadingScr;

    public GameEventSO deathEvent;
    public GameEventSO settingsEvent;

    private bool isGameover = false;    

    private void Start()
    {
        loadingScr.SetActive(false);
        hudParent.SetActive(true);
        settingParent.SetActive(false);
        gameover.SetActive(false);

        isGameover = false;

        deathEvent.onGameEvent.AddListener(SetGameover);
        settingsEvent.onGameEvent.AddListener(OpenSettingMenu);
    }

    public void SetGameover()
    {
        StartCoroutine(FadeOut(hudParent));
        StartCoroutine(FadeIn(gameover));

        isGameover = true;
    }

    public void OpenSettingMenu()
    {
        settingsEvent.onGameEvent.RemoveListener(OpenSettingMenu);
        settingsEvent.onGameEvent.AddListener(CloseSettingMenu);
        Time.timeScale = 0f;
        if (isGameover)
        {
            settingParent.SetActive(true);
            gameover.SetActive(false);
        }
        else
        {
            settingParent.SetActive(true);
            hudParent.SetActive(false);
        }
    }

    public void CloseSettingMenu()
    {
        settingsEvent.onGameEvent.RemoveListener(CloseSettingMenu);
        settingsEvent.onGameEvent.AddListener(OpenSettingMenu);
        Time.timeScale = 1f;
        if (isGameover)
        {
            settingParent.SetActive(false);
            gameover.SetActive(true);
        }
        else
        {
            settingParent.SetActive(false);
            hudParent.SetActive(true);
        }
    }

    IEnumerator FadeOut(GameObject parentObj)
    {
        parentObj.SetActive(true);
        CanvasGroup hudAlpha = parentObj.GetComponent<CanvasGroup>();
        hudAlpha.alpha = 1.0f;

        while (hudAlpha.alpha > 0)
        {
            hudAlpha.alpha -= Time.deltaTime;
            yield return null;
        }
        parentObj.SetActive(false);
    }

    IEnumerator FadeIn(GameObject parentObj)
    {
        parentObj.SetActive(true);
        CanvasGroup hudAlpha = parentObj.GetComponent<CanvasGroup>();        
        hudAlpha.alpha = 0;

        while (hudAlpha.alpha < 1)
        {
            hudAlpha.alpha += Time.deltaTime;
            yield return null;
        }        
    }
}
