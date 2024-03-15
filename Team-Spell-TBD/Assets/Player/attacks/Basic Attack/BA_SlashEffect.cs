using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BA_SlashEffect : MonoBehaviour
{
    public PlayerStatsSO playerStats;

    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] float slashMoveSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        rb.velocity = transform.right * slashMoveSpeed;
        anim.speed = 1 / (1+playerStats.attack_speed_mod);
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
