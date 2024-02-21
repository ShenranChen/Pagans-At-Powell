using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ability1 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ability;
    Rigidbody2D playerRB;
    public unlockAbilitySO abilityUnlocks;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnAbility1()
    {

    }
}
