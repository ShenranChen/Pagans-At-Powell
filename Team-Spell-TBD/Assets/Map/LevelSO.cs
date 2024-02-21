using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelX_data", menuName = "ScriptableObjects/Level", order = 1)]
public class LevelSO : ScriptableObject
{
    // enemy level will be changed and accessed
    public float enemyLevel = 1;

    public float timeFactor = 0.15f;
    public float waveFactor = 1.15f;

    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public GameObject enemy5;

    public float wave1start = 5;
    public float wave2start = 30;
    public float wave3start = 60;
    public float wave4start = 120;
    public float wave5start = 180;

    public float waveBreak = 5;
}
