using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerLetters : MonoBehaviour
{
    public LettersSO letters;

    PlayerInput playerInputManager;
    void Start()
    {
        playerInputManager = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnOpenKeyboardMenu()
    {

    }
}
