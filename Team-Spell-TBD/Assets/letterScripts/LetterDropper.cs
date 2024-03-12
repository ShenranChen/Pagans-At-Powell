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
        float totalKeyProb = 90f;
        float extraLetters = 2f;

        float doubleAppearanceProb = (totalKeyProb / 10) + extraLetters;
        float otherKeyProb = (totalKeyProb - 5*doubleAppearanceProb) / 5;

        int nonKeyCount = 26 - 10; //key letter: r o c k e t, s l a s h, h e a l
        float nonKeyProb = 10f / nonKeyCount;


        letterProbabilities = new Dictionary<char, float>
        {
            {'R', otherKeyProb},
            {'O', otherKeyProb},
            {'C', otherKeyProb},
            {'K', otherKeyProb},
            {'E', doubleAppearanceProb},
            {'T', otherKeyProb},
            {'S', doubleAppearanceProb},
            {'L', doubleAppearanceProb},
            {'A', doubleAppearanceProb},
            {'H', doubleAppearanceProb}
        };

        foreach (char letter in "BDFGIJMNPQUVWXYZ")
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
        float randomNumber = Random.Range(0f, 110f);
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

