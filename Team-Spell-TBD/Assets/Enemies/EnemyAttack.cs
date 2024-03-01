using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public LayerMask playerLayer;

    private float attackInterval = 1;
    private float timer = 0;
    private float currentATK;


    // Start is called before the first frame update
    void Start()
    {
        var enemySetup = this.GetComponent<EnemySetup>();
        if (enemySetup != null)
        {
            currentATK = enemySetup.currentATK;
        }
        else
        {
            Debug.LogError("EnemySetup component not found!");
        }
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Enemy Collided with " + collider.gameObject.name);

        if (collider.gameObject != null && timer <= 0)
        {
            var playerLayerMask = LayerMask.NameToLayer("Player"); // Replace with your actual player layer name
            if (collider.gameObject.layer == playerLayerMask)
            {
                Debug.Log("Player Collision Detected");
                var playerHealthManager = collider.gameObject.GetComponent<PlayerHealthManager>();
                if (playerHealthManager != null)
                {
                    playerHealthManager.TakeDamage(currentATK);
                    timer = attackInterval;
                }
                else
                {
                    Debug.LogError("PlayerHealthManager component not found on collided object.");
                }
            }
        }
    }
}
