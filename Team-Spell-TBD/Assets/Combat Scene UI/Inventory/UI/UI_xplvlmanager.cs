using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_xplvlmanager : MonoBehaviour
{
    [SerializeField] private GameEventSO playerXPGained;

    [SerializeField] private TextMeshProUGUI levelTxt;
    [SerializeField] private Image xpBar;
    [SerializeField] private PlayerXP playerXPInfo;

    void Start()
    {
        playerXPGained.onGameEvent.AddListener(UpdateUI);
        UpdateUI();
    }

    void UpdateUI()
    {
        xpBar.fillAmount = (float)playerXPInfo.currXP / (float)playerXPInfo.XPtoNextLevel;
        levelTxt.text = "Level " + playerXPInfo.currLevel;
    }
}
