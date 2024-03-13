using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOResetStuff : MonoBehaviour
{
    [Header("player")]
    [SerializeField] private PlayerStatsSO playerStats;

    [Header("enemies")]
    [SerializeField] private EnemyStatsSO fastEnemyStats;
    [SerializeField] private EnemyStatsSO slowEnemyStats;


    void Start()
    {
        playerStats.base_HP = 100;
        playerStats.base_ATK = 100;

        playerStats.move_speed_mod = 1;
        playerStats.attack_speed_mod = 0;
        playerStats.ability_cooldown_reduction_mod = 0;

        fastEnemyStats.baseSPD = 1.8f;
        fastEnemyStats.baseHP = 60;
        fastEnemyStats.baseATK = 6;

        slowEnemyStats.baseSPD = 1f;
        slowEnemyStats.baseHP = 150;
        slowEnemyStats.baseATK = 12;
    }
}
