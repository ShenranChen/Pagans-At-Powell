using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BA_SlashEffect : MonoBehaviour
{
    public PlayerStatsSO playerStats;

    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] float slashMoveSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        rb.velocity = transform.right * slashMoveSpeed;
        anim.speed = 1f + playerStats.attack_speed_mod / slashMoveSpeed;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
