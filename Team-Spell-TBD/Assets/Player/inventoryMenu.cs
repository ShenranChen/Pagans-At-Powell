using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryMenu : MonoBehaviour
{
    [SerializeField] private GameEventSO inventoryEvent;

    public void OnSettings()
    {
        inventoryEvent.RaiseEvent();
    }
}
