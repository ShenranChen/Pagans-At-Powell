using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.UI;
using Unity.PlasticSCM.Editor.WebApi;


public class Rocket_player: MonoBehaviour
{
    // Scriptable Objects
    public PlayerStatsSO playerStats;
    public GameEventSO ability2Event;

    // publics
    public Transform firePoint;
    public GameObject projectileEffect;
    public UnlockedAbilitiesSO unlockedRocket;
    public Button rocketButton;

    [SerializeField] private AudioClip scribbleSoundClip;

    [SerializeField] private float baseCooldownTime = 5f;
    [SerializeField] private float minCooldownTime = 0.005f;

    public float currentCooldownTime;
    private float attackCountdown = 0f;

    private void Start()
    {
        currentCooldownTime = baseCooldownTime;
        unlockedRocket.rocket = false;
    }

    void Update()
    {
        // ability countdown timer
        if (attackCountdown > 0)
        {
            attackCountdown -= Time.deltaTime;
            rocketButton.interactable = false;
        }
        else
        {
            if(unlockedRocket.rocket)
            {
                rocketButton.interactable = true;
            }
        }
    }

    // new input manager
    public void OnAbility2()
    {
        if (attackCountdown <= 0 && unlockedRocket.rocket)
        {
            Debug.Log("Rocket attack trig");
            rocketAbility();
        }
        Debug.Log("do nothing");
    }

    private void rocketAbility()
    { 
        Instantiate(projectileEffect, firePoint.position, firePoint.rotation);
        attackCountdown = (currentCooldownTime < minCooldownTime ? minCooldownTime : currentCooldownTime);
        ability2Event.RaiseEvent();

        // play sound
        SoundEffectsManager.instance.PlaySoundFXClip(scribbleSoundClip, transform, PlayerPrefs.GetFloat("volume"));
    }

    public void UpgradeRocket()
    {
        Debug.Log("UPGRADE ROCKET");
        // reduce time between attacks by 15%, max attack speed is 200 attacks per second
        currentCooldownTime = baseCooldownTime * (1 - (playerStats.attack_speed_mod * 0.15f));
    }
}
