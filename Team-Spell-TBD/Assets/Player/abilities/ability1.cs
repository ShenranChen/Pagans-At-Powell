using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ability1 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ability;
    Rigidbody2D abilityRB;
    public unlockAbilitySO abilityUnlocks;
    int abilityHealthVal = 6;

    void Start()
    {
        abilityRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnAbility1()
    {

    }
}
