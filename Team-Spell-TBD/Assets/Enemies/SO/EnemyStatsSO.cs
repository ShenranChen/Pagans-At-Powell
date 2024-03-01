using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Stats", menuName = "ScriptableObjects/EnemyStats", order = 1)]
public class EnemyStatsSO : ScriptableObject
{
    public float baseHP = 50;
    public float baseATK = 10;
    public float baseSPD = 0.2f;
}
