using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using Unity.PlasticSCM.Editor.WebApi;

public class Rocket_player: MonoBehaviour
{
    // Scriptable Objects
    public PlayerStatsSO playerStats;
    public GameEventSO ability2Event;

    // publics
    public Transform firePoint;
    public GameObject projectileEffect;

    [SerializeField] private float baseCooldownTime = 5f;
    [SerializeField] private float minCooldownTime = 0.005f;
    public float currentCooldownTime;
    private float attackCountdown = 0f;

    private void Start()
    {
        currentCooldownTime = baseCooldownTime;
    }

    void Update()
    {
        // ability countdown timer
        if (attackCountdown > 0)
        {
            attackCountdown -= Time.deltaTime;
        }
    }

    // new input manager
    void OnAbility2()
    {
        if (attackCountdown <= 0)
        {
            Debug.Log("Rocket attack trig");
            rocketAbility();
        }
    }

    private void rocketAbility()
    { 
        Instantiate(projectileEffect, firePoint.position, firePoint.rotation);
        attackCountdown = (currentCooldownTime < minCooldownTime ? minCooldownTime : currentCooldownTime);
        ability2Event.RaiseEvent();
    }

    public void UpgradeRocket()
    {
        // reduce time between attacks by 15%, max attack speed is 200 attacks per second
        currentCooldownTime = baseCooldownTime * (1 - (playerStats.attack_speed_mod * 0.15f));
    }
}
