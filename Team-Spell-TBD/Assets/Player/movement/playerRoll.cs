using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Make this script a component of the: Player Game Object

public class playerRoll : MonoBehaviour
{
    [SerializeField] private float rollDuration = 0.2f;
    [SerializeField] private float CooldownDuraiton = 0.5f;
    [SerializeField] private float rollSpeed = 20f;

    [SerializeField] private AudioClip rollSoundClip;

    private float rollTimer;
    private float cooldownTimer;
    private Rigidbody2D rb;
    private Animator ani;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // increment timers
        if (rollTimer > 0) 
        { 
            rollTimer -= Time.deltaTime;
            if (rollTimer <= 0) { endRollAnimation(); }
        }
        if (cooldownTimer > 0) { cooldownTimer -= Time.deltaTime; }
    }

    void OnRoll()
    {
        if (cooldownTimer <= 0)
        {
            // Set timers
            cooldownTimer = CooldownDuraiton;
            rollTimer = rollDuration;
            GetComponent<playerMovement>().disableMovementFor(rollDuration);

            // Set roll speed in current direction
            rb.velocity *= rollSpeed / rb.velocity.magnitude;

            // Activate some visual effect
            startRollAnimation();

            // Play roll sound
            SoundEffectsManager.instance.PlaySoundFXClip(rollSoundClip, transform, PlayerPrefs.GetFloat("volume"));
        }
    }

    void startRollAnimation()
    {
        //GetComponent<SpriteRenderer>().color = Color.grey;
        ani.SetBool("IsRolling", true);
    }

    void endRollAnimation()
    {
        //GetComponent<SpriteRenderer>().color = Color.white;
        ani.SetBool("IsRolling", false);
    }
}
