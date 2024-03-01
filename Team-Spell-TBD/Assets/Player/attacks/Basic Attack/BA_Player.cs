using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class BA_player: MonoBehaviour
{
    // Scriptable Objects
    public PlayerStatsSO playerStats;
    public AbilityEventSO basicAttackEvent;

    // publics
    public Transform firePoint;
    public GameObject slashEffect;

    [SerializeField] private float baseCooldownTime = 2f;
    [SerializeField] private float minCooldownTime = 0.005f;
    private float attackCountdown = 0f;

    void Update()
    {
        // ability countdown timer
        if (attackCountdown > 0)
        {
            attackCountdown -= Time.deltaTime;
        }
    }

    // new input manager
    void OnBasicAttack()
    {
        if (attackCountdown <= 0)
        {
            Debug.Log("basic attack trig");
            basicAttack();
        }
    }

    protected void basicAttack()
    {
        // raise event
        basicAttackEvent.RaiseEvent();

        // 
        Instantiate(slashEffect, firePoint.position, firePoint.rotation);

        // reduce time between attacks by 15%, max attack speed is 200 attacks per second
        float temp = baseCooldownTime * (1 - (playerStats.attack_speed_mod * 0.15f));
        attackCountdown = (temp < minCooldownTime ? minCooldownTime : temp);
    }
}
