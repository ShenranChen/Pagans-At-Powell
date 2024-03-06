using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Interface : MonoBehaviour
{
    public GameObject mainMenu;

    private void Update()
    {
        
    }

    public void PressedStart()
    {
        EventManager.TriggerStartSequence();
    }


}
