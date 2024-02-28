using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public PlayerStatsSO playerStats;
    public unlockAbilitySO unlockAbility;
    private float currentHP;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = playerStats.base_HP;
        unlockAbility.ability1 = false;
        unlockAbility.ability2 = false;
    }
}
