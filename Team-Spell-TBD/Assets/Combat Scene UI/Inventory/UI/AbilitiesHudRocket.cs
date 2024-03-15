using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AbilitiesHudRocket : MonoBehaviour
{
    public GameEventSO abilityEvent;
    public Rocket_player rocketAttackInfo;
    public Image cooldown;
    public UnlockedAbilitiesSO unlockedAbilities;

    private float currTimer = 0;
    private float maxTimer = 0;

    // Start is called before the first frame update
    private void Start()
    {
        abilityEvent.onGameEvent.AddListener(StartTimer);
        cooldown.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (unlockedAbilities.rocket)
        {
            if (currTimer > 0)
            {
                cooldown.fillAmount = currTimer / maxTimer;
                currTimer -= Time.deltaTime;
            }
            else
            {
                currTimer = 0;
                cooldown.fillAmount = 0;
            }
        }
    }

    public void StartTimer()
    {
        maxTimer = rocketAttackInfo.currentCooldownTime;
        currTimer = maxTimer;
        cooldown.fillAmount = 1;
    }
}
