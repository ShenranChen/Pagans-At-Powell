using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using Unity.PlasticSCM.Editor.WebApi;

public class BA_player: MonoBehaviour
{
    // Scriptable Objects
    public PlayerStatsSO playerStats;
    public GameEventSO basicAttackEvent;

    // publics
    public Transform firePoint;
    public GameObject slashEffect;

    [SerializeField] private AudioClip basicAttackSoundClip;

    [SerializeField] private float baseCooldownTime = 2f;
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
    void OnBasicAttack()
    {
        if (attackCountdown <= 0)
        {
            Debug.Log("basic attack trig");
            basicAttack();
        }
    }

    private void basicAttack()
    { 
        Instantiate(slashEffect, firePoint.position, firePoint.rotation);
        attackCountdown = (currentCooldownTime < minCooldownTime ? minCooldownTime : currentCooldownTime);
        basicAttackEvent.RaiseEvent();

        SoundEffectsManager.instance.PlaySoundFXClip(basicAttackSoundClip, transform, 1f);
    }

    public void UpgradeBasicAttack()
    {
        Debug.Log("UPGRADE SLASH");
        // reduce time between attacks by 15%, max attack speed is 200 attacks per second
        currentCooldownTime = baseCooldownTime * (1 - (playerStats.attack_speed_mod * 0.15f));
    }
}
