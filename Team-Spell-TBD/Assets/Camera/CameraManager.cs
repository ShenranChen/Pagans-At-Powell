using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;

public class CameraManager : MonoBehaviour
{
    // Public variables
    public GameObject cam;
    public GameObject player;

    // Private variables
    private Vector2 cameraPosition;
    private Vector2 playerPosition;
    private float cameraFollowSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CamGameMode();
    }

    void CamGameMode()
    {
        // get camera and player positions
        cameraPosition = new Vector2(cam.GetComponent<Rigidbody2D>().position.x, cam.GetComponent<Rigidbody2D>().position.y);
        playerPosition = new Vector2(player.GetComponent<Rigidbody2D>().position.x, player.GetComponent<Rigidbody2D>().position.y);

        // find vector from camera to player
        Vector2 c2p = playerPosition - cameraPosition;

        // move camera in direction of player
        cam.GetComponent<Rigidbody2D>().velocity = cameraFollowSpeed * c2p;
    }
}
