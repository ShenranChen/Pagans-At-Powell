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

    public int waveNum;
    private bool isSpawnPhase;
    private float waveLength = 40;
    private float waveRest = 10;

    private float spawnIntervalSlow = 6f;
    private float spawnIntervalFast = 3f;

    private float timer;

    private void Start()
    {
        timer = 0;
        isSpawnPhase = true;
        waveNum = 1;

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

            fastEnemySpawner.spawnInterval = 10000;
            slowEnemySpawner.spawnInterval = 10000;
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

    private void IncreaseDifficulty() //lower spawn interval, increase enemy attack, increase enemy HP, increase enemy SPD
    {
        spawnIntervalFast *= 0.9f;
        spawnIntervalSlow *= 0.9f;

        fastEnemyStats.baseATK *= 1.2f;
        slowEnemyStats.baseATK *= 1.2f;

        fastEnemyStats.baseHP *= 1.5f;
        slowEnemyStats.baseHP *= 1.5f;

        fastEnemyStats.baseSPD *= 1.05f;
        slowEnemyStats.baseSPD *= 1.05f;
    }
}
