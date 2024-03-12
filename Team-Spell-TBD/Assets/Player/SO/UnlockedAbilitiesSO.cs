using UnityEngine;

[CreateAssetMenu(fileName = "new ability unlock SO", menuName = "ScriptableObjects/AbilityStuff/UnlockedAbilities", order = 1)]
public class UnlockedAbilitiesSO : ScriptableObject
{
    public bool heal = false;
    public bool rocket = false;
}
