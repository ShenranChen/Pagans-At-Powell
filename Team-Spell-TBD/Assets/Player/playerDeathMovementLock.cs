using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDeathMovementLock : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRB;
    [SerializeField] private GameEventSO playerDeath;
    // Start is called before the first frame update
    void Start()
    {
        playerRB.constraints = RigidbodyConstraints2D.None;
        playerRB.constraints = RigidbodyConstraints2D.FreezeRotation;
        playerDeath.onGameEvent.AddListener(PlayerFreezeMovement);
    }

    void PlayerFreezeMovement()
    {
        playerRB.constraints = RigidbodyConstraints2D.FreezePosition;
    }
}
