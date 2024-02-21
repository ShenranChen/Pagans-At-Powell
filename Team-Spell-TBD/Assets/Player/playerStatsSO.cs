using UnityEngine;

[CreateAssetMenu(fileName = "Player Stats", menuName = "ScriptableObjects/PlayerStats", order = 1)]
public class PlayerStatsSO : ScriptableObject
{
    // stats
    public int move_speed_mod = 0;
    public int attack_speed_mod = 0;
    public int ability_cooldown_reduction_mod = 0;
    public int attackSize_mod = 0;

    // other stats
    public int base_HP = 100;
    public int base_ATK = 50;
}
