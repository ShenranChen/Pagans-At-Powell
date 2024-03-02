using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public GameEventSO playerDeath;
    public PlayerStatsSO playerStats;
    public UnlockedAbilitiesSO unlockedAbilities;
    private float currentHP;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = playerStats.base_HP;
        unlockedAbilities.ability1 = false;
        unlockedAbilities.ability2 = false;
    }

    public void TakeDamage(float damage)
    {
        Debug.Log("Player Took Dmg: " + damage);
        Debug.Log("Player Health: " + currentHP);
        currentHP -= damage;

        if(currentHP < 0 )
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player Died");
        this.GetComponent<SpriteRenderer>().enabled = false;
        playerDeath.RaiseEvent();
    }
}
