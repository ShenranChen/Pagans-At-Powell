using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket_ProjectileEffect : MonoBehaviour
{
    public PlayerStatsSO playerStats;

    private Rigidbody2D rb;
    private Animator anim;

    private float liveTime = 0f;

    [SerializeField] float projectileMoveSpeed = 30f; // The speed of the rocket when it launches
    [SerializeField] float stallTime = 1f; // The amount of time the rocket takes before it launches in seconds

    [SerializeField] private AudioClip strokeSoundClip;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {

        if (liveTime >= 0)
        {
            if (liveTime > stallTime)
            {
                rb.velocity = transform.right * projectileMoveSpeed;
                anim.speed = 1f + playerStats.attack_speed_mod / projectileMoveSpeed;

                // play stroke sound
                SoundEffectsManager.instance.PlaySoundFXClip(strokeSoundClip, transform, PlayerPrefs.GetFloat("volume"));

                liveTime = -1f;
            }
            else { liveTime += Time.deltaTime; }
        }

    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
