using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInv : MonoBehaviour
{
    public LettersSO lettersInventory;

    // Start is called before the first frame update
    void Start()
    {
        lettersInventory.A = 0;
        lettersInventory.B = 0;
        lettersInventory.C = 0; 
        lettersInventory.D = 0; 
        lettersInventory.E = 0; 
        lettersInventory.F = 0; 
        lettersInventory.G = 0; 
        lettersInventory.H = 0; 
        lettersInventory.I = 0; 
        lettersInventory.J = 0; 
        lettersInventory.K = 0; 
        lettersInventory.L = 0; 
        lettersInventory.M = 0; 
        lettersInventory.N = 0; 
        lettersInventory.O = 0; 
        lettersInventory.P = 0; 
        lettersInventory.Q = 0; 
        lettersInventory.R = 0; 
        lettersInventory.S = 0; 
        lettersInventory.T = 0; 
        lettersInventory.U = 0; 
        lettersInventory.V = 0; 
        lettersInventory.W = 0; 
        lettersInventory.X = 0; 
        lettersInventory.Y = 0; 
        lettersInventory.Z = 0; 

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddLetterToInventory(char letter)
    {
        switch (letter)
        {
            case 'A': lettersInventory.A++; break;
            case 'B': lettersInventory.B++; break;
            case 'C': lettersInventory.C++; break;
            case 'D': lettersInventory.D++; break;
            case 'E': lettersInventory.E++; break;
            case 'F': lettersInventory.F++; break;
            case 'G': lettersInventory.G++; break;
            case 'H': lettersInventory.H++; break;
            case 'I': lettersInventory.I++; break;
            case 'J': lettersInventory.J++; break;
            case 'K': lettersInventory.K++; break;
            case 'L': lettersInventory.L++; break;
            case 'M': lettersInventory.M++; break;
            case 'N': lettersInventory.N++; break;
            case 'O': lettersInventory.O++; break;
            case 'P': lettersInventory.P++; break;
            case 'Q': lettersInventory.Q++; break;
            case 'R': lettersInventory.R++; break;
            case 'S': lettersInventory.S++; break;
            case 'T': lettersInventory.T++; break;
            case 'U': lettersInventory.U++; break;
            case 'V': lettersInventory.V++; break;
            case 'W': lettersInventory.W++; break;
            case 'X': lettersInventory.X++; break;
            case 'Y': lettersInventory.Y++; break;
            case 'Z': lettersInventory.Z++; break;
            default: break;
        }
    }
}
