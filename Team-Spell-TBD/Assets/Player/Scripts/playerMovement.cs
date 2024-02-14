using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    // Private variables
    private Rigidbody2D rb;
    private Vector2 inputVector;

    // Serialized private variables
    [SerializeField] private float playerSpeed = 5f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = inputVector * playerSpeed;
    }

    // OnMove is called on button press of move action
    void OnMove(InputValue val)
    {
        inputVector = val.Get<Vector2>().normalized;
    }
}
