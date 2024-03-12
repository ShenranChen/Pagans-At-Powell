using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public GameEventSO playerDeath;
    public GameEventSO playerTakeDamage;
    public PlayerStatsSO playerStats;
    public TextMeshProUGUI healthText;
    public UnlockedAbilitiesSO unlockedHeal;
    public LettersSO lettersInventory;
    public float currentHP;
    public float shieldHealth;

    private bool isDead;

    [SerializeField] private AudioClip healSoundClip;

    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        shieldHealth = 0;
        currentHP = playerStats.base_HP;
        unlockedHeal.heal = false;
        healthText.text = currentHP.ToString() + " / " + currentHP.ToString();

        //GainAbility(100000);
    }

    public void TakeDamage(float damage)
    {
        currentHP -= CalcShieldHealth(damage);

        Debug.Log("Player Took Dmg: " + damage);
        Debug.Log("Player Health: " + currentHP);
        Debug.Log("Player Shield: " + shieldHealth);

        if (currentHP < 0 && isDead == false)
        {
            isDead = true;
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

   public void OnAbility1()
    {
        if(unlockedHeal.heal && lettersInventory.H > 0 && lettersInventory.E > 0 &&
            lettersInventory.A > 0 && lettersInventory.L > 0)
        {
            lettersInventory.H--;
            lettersInventory.E--;
            lettersInventory.A--;
            lettersInventory.L--;

            HealAbility();
        }
    }

    public void HealAbility()
    {
        currentHP += 40;
        float tempHp = currentHP;
        if(currentHP > playerStats.base_HP)
        {
            currentHP = playerStats.base_HP;
            tempHp -= currentHP;
            shieldHealth += tempHp;
        }
        playerTakeDamage.RaiseEvent();

        // Play heal sound
        SoundEffectsManager.instance.PlaySoundFXClip(healSoundClip, transform, PlayerPrefs.GetFloat("volume"));
    }
}
