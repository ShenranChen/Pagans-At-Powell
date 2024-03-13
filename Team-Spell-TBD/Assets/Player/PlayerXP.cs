using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerXP : MonoBehaviour
{
    // GameEventSO
    public GameEventSO playerTookDamage;
    public GameEventSO gainedXP;

    // to display
    public int currLevel = 1;
    public int currXP = 0;
    public int XPtoNextLevel = 7;

    // imports
    [SerializeField] private PlayerStatsSO playerStats;
    [SerializeField] DifficultyManager difficultyManager;
    private int waveNum;

    private float incrXP = 1.2f;

    private void Start()
    {
        waveNum = difficultyManager.waveNum;
        currXP = 0;
        currLevel = 1;
    }

    private void LevelUp()
    {
        currLevel++;
        currXP = 0;
        XPtoNextLevel = Mathf.FloorToInt(incrXP * XPtoNextLevel);

        playerStats.base_ATK *= 1.1f;
        playerStats.base_HP *= 1.1f;
        playerStats.move_speed_mod *= 1.05f;
        playerTookDamage.RaiseEvent();
    }

    public void CollectedLetter()
    {
        currXP += 1 + Mathf.FloorToInt(waveNum  * 0.4f);
        if (currXP >= XPtoNextLevel)
        {
            LevelUp();
        }
        gainedXP.RaiseEvent();
    }
}
