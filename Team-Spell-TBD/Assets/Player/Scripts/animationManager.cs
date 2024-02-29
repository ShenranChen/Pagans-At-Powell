using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Make this script a component of the: Player Game Object

public class animationManager : MonoBehaviour
{
    // Private variables
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
        // Depending on current player velocity, set WalkDirection for the walking animation
        if (rb.velocity.y > 0f) { ani.SetInteger("WalkDirection", 1); }
        else if (rb.velocity.y < 0f) { ani.SetInteger("WalkDirection", 3); }
        else if (rb.velocity.x < 0f) { ani.SetInteger("WalkDirection", 4); }
        else if (rb.velocity.x > 0f) { ani.SetInteger("WalkDirection", 2); }
        else { ani.SetInteger("WalkDirection", 0); }
    }
}
