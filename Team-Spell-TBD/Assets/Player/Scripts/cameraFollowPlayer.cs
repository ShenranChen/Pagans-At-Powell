using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollowPlayer : MonoBehaviour
{
    // Public variables
    public GameObject camera;
    public GameObject player;

    // Private variables
    private Vector2 cameraPosition;
    private Vector2 playerPosition;

    // Serialized variables
    [SerializeField] private float cameraFollowSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // get camera and player positions
        cameraPosition = new Vector2(camera.GetComponent<Rigidbody2D>().position.x, camera.GetComponent<Rigidbody2D>().position.y);
        playerPosition = new Vector2(player.GetComponent<Rigidbody2D>().position.x, player.GetComponent<Rigidbody2D>().position.y);

        // find vector from camera to player
        Vector2 c2p = playerPosition - cameraPosition;

        // move camera in direction of player
        camera.GetComponent<Rigidbody2D>().velocity = cameraFollowSpeed * c2p;

    }
}
