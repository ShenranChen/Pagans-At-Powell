using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Letter", menuName = "ScriptableObjects/Letter Data")]
public class LetterData : ScriptableObject
{
    public char letter;
    public GameObject prefab;
}

