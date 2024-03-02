using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySetup : MonoBehaviour
{
    // Scriptable Object
    public LevelSO levelData;
    public EnemyStatsSO enemyStats;

    //class specific
    private float currentHP;
    public float currentATK;
    public float currentSPD;

    private LetterDropper letterDropper;
    private LetterDisplay letterDisplay;

    void Start()
    {
        currentHP = enemyStats.baseHP + (levelData.enemyLevel * 0.8f);
        currentATK = enemyStats.baseATK + (levelData.enemyLevel * 0.8f);
        currentSPD = enemyStats.baseSPD + (levelData.enemyLevel * 0.2f);
        
        letterDropper = GetComponent<LetterDropper>();
        letterDisplay = GetComponent<LetterDisplay>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        Debug.Log("Took dmg: " + damage + "\n Enemy Health: " + currentHP);

        currentHP -= damage;

        if (currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        char letterToDrop = letterDropper.ChooseLetter();
        Debug.Log(letterToDrop);

        Vector3 currPos = transform.position;
        gameObject.SetActive(false);

        if (letterToDrop != ' ')
        {
            letterDisplay.SpawnLetter(letterToDrop, currPos);
        }

        Debug.Log("Enemy Died");
        Destroy(gameObject);        
    }
}
