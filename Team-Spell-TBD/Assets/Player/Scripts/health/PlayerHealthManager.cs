using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public PlayerStatsSO playerStats;

    private float currentHP;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = playerStats.base_HP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
