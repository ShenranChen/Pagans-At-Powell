using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AbilitiesHud : MonoBehaviour
{
    public GameEventSO basicAttackEvent;
    public BA_player basicAttackInfo;
    public Image cooldown;

    private float currTimer = 0;
    private float maxTimer = 0;

    // Start is called before the first frame update
    private void Start()
    {
        basicAttackEvent.onGameEvent.AddListener(StartTimer);
        cooldown.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (currTimer > 0)
        {
            cooldown.fillAmount = currTimer / maxTimer;
            currTimer -= Time.deltaTime;
        }
    }

    public void StartTimer()
    {
        maxTimer = basicAttackInfo.currentCooldownTime;
        currTimer = maxTimer;
        cooldown.fillAmount = 1;
    }
}
