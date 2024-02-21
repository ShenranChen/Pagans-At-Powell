using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class basic_attack : MonoBehaviour
{
    //SO
    public PlayerStatsSO playerStats;

    //class specific values
    //public Animator animator;
    [SerializeField] private float baseCooldownTime = 2f;
    [SerializeField] private float minCooldownTime = 0.005f;
    private float attackCountdown = 0f;
    private float base_attackRange = 2f;
    private float dist_to_attack = 1f;
    private float base_MV = 0.5f;
    private float newAttackRange;

    //public Animator animator;
    public Transform attackPoint;
    public LayerMask enemyLayer;

    Vector3 normDirToMouse;

    // Start is called before the first frame update
    void Start()
    {
        abilityLevel = 1;
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

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position + (normDirToMouse * dist_to_attack), newAttackRange);
    }

    private void basicAttack()
    {
        // animation
        ////animator.SetTrigger("basic attack");

        //Debug.Log("BA func trig");

        // collider/triggers
        newAttackRange = base_attackRange + (base_attackRange * playerStats.attackSize_mod * 0.1f);
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position + (normDirToMouse * dist_to_attack), newAttackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("Enemy hit:  " + enemy.name);
            enemy.GetComponent<EnemySetup>().TakeDamage(base_MV * playerStats.base_ATK * playerStats.ba_level);
        }




        // attack cooldown logic
        // reduce time between attacks by 15%, max attack speed is 200 attacks per second
        float temp = baseCooldownTime * (1 - (playerStats.attack_speed_mod * 0.15f));
        attackCountdown = (temp < minCooldownTime ? minCooldownTime : temp);
    }

    private Vector3 GetWorldPositionOfMouse()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        // Set mouseScreenPosition.z to be the distance from the camera to the player
        mouseScreenPosition.z = Camera.main.WorldToScreenPoint(transform.position).z;

        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        // For a 2D game, you might not need the Z component, and it can be ignored or set to a specific value
        mouseWorldPosition.z = 0; // Set to 0 or appropriate Z value for your game

        return mouseWorldPosition;
    }
}