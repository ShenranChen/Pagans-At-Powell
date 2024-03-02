using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Make this script a component of the: Player Game Object

public class playerMovement : MonoBehaviour
{
    // Public variables

    // Private variables
    private Rigidbody2D rb;
    private Vector2 inputVector;
    private float disableMovementTimer = 0f;

    // Serialized private variables
    [SerializeField] private float playerSpeed = 5f;

    private PlayerInv playerLetterInv;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerLetterInv = GetComponent<PlayerInv>();
    }

    // Update is called once per frame
    void Update()
    {
        if (disableMovementTimer <= 0) { rb.velocity = inputVector * playerSpeed; }
        else { disableMovementTimer -= Time.deltaTime; }
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Letter"))
        {
            playerLetterInv.AddLetterToInventory(other.gameObject.name[0]);
            Destroy(other.gameObject);
        }
    }
}
