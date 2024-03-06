using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;

public class CameraManager : MonoBehaviour
{
    // GameEvent


    // Public variables
    public GameObject cam;
    public GameObject player;

    public float resetDuration = 5f;

    // Private variables
    private Vector2 cameraPosition;
    private Vector2 playerPosition;
    private Camera camComp;
    private Vector3 initPos = new Vector3(0f, 1.27f, -10f);
    private float cameraFollowSpeed = 5f;
    private float startFov = 2.53f;
    private float zoomSpeed = 0.01f;
    private float gameFov = 5f;

    // Start is called before the first frame update
    void Start()
    {
        camComp = cam.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (EventManager.gameState == "menu")
        {
            cam.transform.position = initPos;
            camComp.orthographicSize = startFov;
        }
        else if (EventManager.gameState == "start")
        {
            CamFov();
            CamGameMode();
        }
        else if (EventManager.gameState == "game")
        {
            CamGameMode();
        }
    }

    void CamFov()
    {
        if (camComp.orthographicSize < gameFov)
        {
            camComp.orthographicSize += zoomSpeed;
        }
        else
        {
            camComp.orthographicSize = gameFov;
            EventManager.EndStartSequence();
        }
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
