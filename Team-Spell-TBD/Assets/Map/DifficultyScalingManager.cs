using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyScalingManager : MonoBehaviour
{
    //Scriptable Objects
    public LevelSO levelData;

    //class specific
    private float secs;
    private float mins;
    private float currWave;
    private float enemyLevel;

    // Start is called before the first frame update
    void Start()
    {
        enemyLevel = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= levelData.wave5start)
        {
            currWave = 5;
        }
        else if (Time.time >= levelData.wave4start)
        {
            currWave = 4;
        }
        else if (Time.time >= levelData.wave3start)
        {
            currWave = 3;
        }
        else if (Time.time >= levelData.wave2start)
        {
            currWave = 2;
        }
        else if (Time.time >= levelData.wave1start)
        {
            currWave = 1;
        }
    }

    void CalcTime()
    {
        secs = Mathf.FloorToInt(Time.time);
        mins = Mathf.FloorToInt(Time.time / 60);
    }
}
