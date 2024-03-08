using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterDropper : MonoBehaviour
{

    private Dictionary<char, float> letterProbabilities;
    private List<KeyValuePair<char, float>> cumulativeProbabilities;

    // Start is called before the first frame update
    void Start()
    {
        InitializeProbabilities();
        CalculateCumulativeProbabilities();
    }

    // Update is called once per frame
    void Update()
    {

    }


    void InitializeProbabilities()
    {
        float totalKeyProb = 80f;
        float extra4E = 2f;

        float eProb = (totalKeyProb / 9) + extra4E;
        float otherKeyProb = (totalKeyProb - eProb) / 8;

        int nonKeyCount = 26 - 9; //key letter: r o c k e t h a l
        float nonKeyProb = 20f / nonKeyCount;


        letterProbabilities = new Dictionary<char, float>
        {
            {'R', otherKeyProb},
            {'O', otherKeyProb},
            {'C', otherKeyProb},
            {'K', otherKeyProb},
            {'E', eProb},
            {'T', otherKeyProb},
            {'H', otherKeyProb},
            {'A', otherKeyProb},
            {'L', otherKeyProb}
        };

        foreach (char letter in "BDFGIJMNPQSUVWXYZ")
        {
            letterProbabilities[letter] = nonKeyProb;
        }

        //seeing the dict debugging
        //foreach (var kvp in letterProbabilities)
        //{
        //    Debug.Log("Letter: " + kvp.Key + ", Probability: " + kvp.Value);
        //}
    }

    void CalculateCumulativeProbabilities()
    {
        cumulativeProbabilities = new List<KeyValuePair<char, float>>();
        float cumulative = 0f;

        foreach (var item in letterProbabilities)
        {
            cumulative += item.Value;
            cumulativeProbabilities.Add(new KeyValuePair<char, float>(item.Key, cumulative));
        }

        //seeing the list debugging
        //foreach (var kvp in cumulativeProbabilities)
        //{
        //    Debug.Log("Letter: " + kvp.Key + ", Probability: " + kvp.Value);
        //}
    }

    public char ChooseLetter()
    {
        float randomNumber = Random.Range(100f, 100f);
        Debug.Log(randomNumber);
        foreach (var item in cumulativeProbabilities)
        {
            if (randomNumber <= item.Value)
            {
                return item.Key;
            }
        }

        //cumulative adds up to 99.999
        if (randomNumber == 100f)
        {
            return 'Z';
        }

        Debug.Log("BAD");

        return ' ';
    }

}

