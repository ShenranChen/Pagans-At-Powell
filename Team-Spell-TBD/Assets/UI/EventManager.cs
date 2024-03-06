using UnityEngine;
using System;

public class EventManager
{
    public static string gameState = "menu";

    public static void TriggerStartSequence()
    {
        gameState = "start";
    }

    public static void EndStartSequence()
    {
        gameState = "game";
    }
}
