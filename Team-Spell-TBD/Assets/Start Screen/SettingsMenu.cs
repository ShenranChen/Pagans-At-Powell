using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    [Header("menu screens")]
    [SerializeField] private GameObject settingsScreen;
    [SerializeField] private GameObject mainMenu;

    public void SettingBtn()
    {
        mainMenu.SetActive(false);
        settingsScreen.SetActive(true);
    }

    public void ReturnMainMenuBtn()
    {
        settingsScreen.SetActive(false);
        mainMenu.SetActive(true);
    }
}
