using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

// Make this script a component of the: Player Game Object

public class playerMovement : MonoBehaviour
{
    // Public variables
    public GameEventSO playerDeath;
    public PlayerStatsSO playerStats;

    // Private variables
    private Rigidbody2D rb;
    private Vector2 inputVector;
    private float disableMovementTimer = 0f;
    private bool playerDead = false;

    // Serialized private variables
    [SerializeField] private float playerSpeed = 5f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerDeath.onGameEvent.AddListener(DisableMovementDeath);
    }

    // Update is called once per frame
    void Update()
    {
        if (disableMovementTimer <= 0 && !playerDead) 
        {
            rb.velocity = inputVector * playerSpeed * playerStats.move_speed_mod;
        }
        else 
        {
            disableMovementTimer -= Time.deltaTime;
        }
    }

    // OnMove is called on button press of move action
    void OnMove(InputValue val)
    {
        inputVector = val.Get<Vector2>().normalized;
    }

    public void disableMovementFor(float timeInSeconds)
    {
        disableMovementTimer = timeInSeconds;
    }

    void DisableMovementDeath()
    {
        playerDead = true;
    }
}
