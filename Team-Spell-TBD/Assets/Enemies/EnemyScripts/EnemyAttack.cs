using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public LayerMask playerLayer;

    private float attackCD = 1;
    private float timer = 0;
    private float currentATK;
    private PlayerHealthManager playerHealth;

    [SerializeField] private AudioClip playerHurtSoundClip;

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
        else if (playerHealth != null && timer <= 0)
        {
            playerHealth.TakeDamage(currentATK);
            timer = attackCD;

            // Play hurt sound
            SoundEffectsManager.instance.PlaySoundFXClip(playerHurtSoundClip, transform, PlayerPrefs.GetFloat("volume"));
        }
    }
    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject != null && collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Debug.Log("Enemy Collider Enter Player");
            playerHealth = collider.gameObject.GetComponent<PlayerHealthManager>();
        }
    }

    private void OnCollisionExit2D(Collision2D collider)
    {
        if (collider.gameObject != null && collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Debug.Log("Enemy Collider Exit Player");
            playerHealth = null;
        }
    }
}
