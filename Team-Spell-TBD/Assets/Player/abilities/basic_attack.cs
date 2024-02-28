using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class basic_attack : MonoBehaviour
{
    //SO
    public PlayerStatsSO playerStats;
    public AbilityEventSO abilityEvent;

    //outside objects
    public Animator animator;
    public Collider2D slashObj;
    public Transform playerPos;

    //ba stats
    [SerializeField] private float baseCooldownTime = 2f;
    [SerializeField] private float minCooldownTime = 0.005f;
    private float attackCountdown = 0f;
    private float base_MV = 0.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = GetWorldPositionOfMouse();
        Vector3 playerPos = transform.position;
        Vector3 dirToMouse = mousePos - playerPos;
        normDirToMouse = dirToMouse.normalized;

        //timer setup
        if (attackCountdown > 0)
        {
            attackCountdown -= Time.deltaTime;
        }
    }

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
        // animation
        animator.SetTrigger("basic attack");

        //Debug.Log("BA func trig");
        abilityEvent.RaiseEvent();        

        // reduce time between attacks by 15%, max attack speed is 200 attacks per second
        float temp = baseCooldownTime * (1 - (playerStats.attack_speed_mod * 0.15f));
        attackCountdown = (temp < minCooldownTime ? minCooldownTime : temp);
    }
}