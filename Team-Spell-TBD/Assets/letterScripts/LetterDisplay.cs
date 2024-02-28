using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterDisplay : MonoBehaviour
{
    //need to change to 26
    public LetterData[] letters = new LetterData[2];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnLetter(char letter, Vector3 position)
    {
        foreach (var letterData in letters)
        {
            if (letterData.letter == letter)
            {
                Instantiate(letterData.prefab, position, Quaternion.identity);
                return;
            }
        }
    }
}
