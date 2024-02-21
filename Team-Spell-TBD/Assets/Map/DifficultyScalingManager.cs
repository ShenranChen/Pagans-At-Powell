using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyScalingManager : MonoBehaviour
{
    //Scriptable Objects
    public LevelSO levelData;

    //class specific
    private float currWave;
    private float levelTime;

    // Start is called before the first frame update
    void Start()
    {
        levelTime = 0;
        currWave = 0;
        levelData.enemyLevel = 1;
    }

    // Update is called once per frame
    void Update()
    {
        levelTime += Time.deltaTime;

        if (levelTime >= levelData.wave5start)
        {
            currWave = 5;
        }
        else if (levelTime >= levelData.wave4start)
        {
            currWave = 4;
        }
        else if (levelTime >= levelData.wave3start)
        {
            currWave = 3;
        }
        else if (levelTime >= levelData.wave2start)
        {
            currWave = 2;
        }
        else if (levelTime >= levelData.wave1start)
        {
            currWave = 1;
        }

        CalcEnemyLevel();
    }

    void CalcEnemyLevel()
    {
        levelData.enemyLevel = Mathf.FloorToInt((levelTime / 60) * levelData.timeFactor * Mathf.Pow(levelData.waveFactor, currWave));
    }
}
