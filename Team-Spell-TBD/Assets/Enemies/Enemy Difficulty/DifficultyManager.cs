using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    [SerializeField] private EnemySpawn fastEnemySpawner;
    [SerializeField] private EnemySpawn slowEnemySpawner;

    [SerializeField] private EnemyStatsSO fastEnemyStats;
    [SerializeField] private EnemyStatsSO slowEnemyStats;

    [SerializeField] private TextMeshProUGUI waveStatus;

    private int waveNum;
    private bool isSpawnPhase;
    private float waveLength = 60;
    private float waveRest = 10;

    private float spawnIntervalSlow = 3f;
    private float spawnIntervalFast = 6f;

    private float timer;

    private void Start()
    {
        timer = 0;
        isSpawnPhase = true;
        waveNum = 0;

        slowEnemySpawner.spawnInterval = spawnIntervalSlow;
        fastEnemySpawner.spawnInterval = spawnIntervalFast;

        waveStatus.text = "Wave: " + waveNum + " | Spawn Phase: " + isSpawnPhase + " | ";
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (isSpawnPhase && timer > waveLength) // at end of spawn phase
        {
            isSpawnPhase = false;
            timer = 0;

            waveStatus.text = "Wave: " + waveNum + " | Spawn Phase: " + isSpawnPhase + " | ";

            fastEnemySpawner.spawnInterval = 0;
            slowEnemySpawner.spawnInterval = 0;
        }
        else if (!isSpawnPhase && timer > waveRest) // at end of rest phase
        {
            isSpawnPhase = true;            
            timer = 0;

            waveNum++;

            waveStatus.text = "Wave: " + waveNum + " | Spawn Phase: " + isSpawnPhase + " | ";

            
            IncreaseDifficulty();

            slowEnemySpawner.spawnInterval = spawnIntervalSlow;
            fastEnemySpawner.spawnInterval = spawnIntervalFast;
        }
    }

    private void IncreaseDifficulty()
    {
        
    }
}
