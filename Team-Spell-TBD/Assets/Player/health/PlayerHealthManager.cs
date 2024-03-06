using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public GameEventSO playerDeath;
    public GameEventSO playerTakeDamage;
    public PlayerStatsSO playerStats;
    public TextMeshProUGUI healthText;
    public UnlockedAbilitiesSO unlockedAbilities;
    public float currentHP;
    public float shieldHealth;

    // Start is called before the first frame update
    void Start()
    {
        shieldHealth = 0;
        currentHP = playerStats.base_HP;

        unlockedAbilities.ability1 = false;
        unlockedAbilities.ability2 = false;

        healthText.text = currentHP.ToString() + " / " + currentHP.ToString();

        //GainAbility(10);
    }

    public void TakeDamage(float damage)
    {
        currentHP -= CalcShieldHealth(damage);

        Debug.Log("Player Took Dmg: " + damage);
        Debug.Log("Player Health: " + currentHP);
        Debug.Log("Player Shield: " + shieldHealth);

        if (currentHP < 0 )
        {
            Die();
        }

        playerTakeDamage.RaiseEvent();
    }

    private void Die()
    {
        Debug.Log("Player Died");
        this.GetComponent<SpriteRenderer>().enabled = false;
        playerDeath.RaiseEvent();
    }

    private float CalcShieldHealth(float damage)
    {
        shieldHealth -= damage;
        if(shieldHealth < 0)
        {
            damage = -1*shieldHealth;
            shieldHealth = 0;
        } else
        {
            damage = 0;
        }
        return damage;
    }

    public void GainAbility(int ab_WordLength)
    {
        shieldHealth += ab_WordLength * 10;
    }
}
