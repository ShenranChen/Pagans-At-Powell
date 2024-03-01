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

    // ability levels
    public int a1_level = 1;
    public int a2_level = 1;
    public int ba_level = 1;

    // ability MV
    public float a1_MV = 1.5f;
    public float a2_MV = 3f;
    public float ba_MV = 0.7f;
}
