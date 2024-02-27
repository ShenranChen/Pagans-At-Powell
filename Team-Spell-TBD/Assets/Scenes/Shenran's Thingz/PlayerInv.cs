using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInv : MonoBehaviour
{
    public LettersSO lettersInventory;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Letter"))
        {
            AddLetterToInventory(other.gameObject.name[0]);
            Destroy(other.gameObject);
        }
    }
    void AddLetterToInventory(char letter)
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
