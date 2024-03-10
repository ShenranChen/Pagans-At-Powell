using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settingMenu : MonoBehaviour
{
    [SerializeField] private GameEventSO settingsEvent;

    public void OnSettings()
    {
        settingsEvent.RaiseEvent();
    }
}
