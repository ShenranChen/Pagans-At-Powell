using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBar;
    public Image shieldBar;
    public TextMeshProUGUI healthText;
    public PlayerStatsSO playerStats;
    public PlayerHealthManager playerHealth;

    public GameEventSO playerTookDamage;

    private void Start()
    {
        shieldBar.fillAmount = 0;
        playerTookDamage.onGameEvent.AddListener(TakeDamage);
    }

    public void TakeDamage()
    {
        healthBar.fillAmount = playerHealth.currentHP / 100f;
        float shieldVal1 = playerHealth.shieldHealth / playerHealth.currentHP;
        shieldBar.fillAmount = shieldVal1 > 1 ? 1 : shieldVal1;
        healthText.text = Mathf.FloorToInt(playerHealth.shieldHealth + playerHealth.currentHP).ToString() + " / " + playerHealth.playerStats.base_HP.ToString();
    }
}
