using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSequence : MonoBehaviour
{
    void Start()
    {
        EventManager.TriggerStartSequence();
    }
}
