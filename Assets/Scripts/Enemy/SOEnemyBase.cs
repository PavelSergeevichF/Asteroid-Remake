
using UnityEngine;

[CreateAssetMenu(fileName = "SOEnemyBase", menuName = "Enemy/SOEnemyBase", order = 1)]
public class SOEnemyBase : ScriptableObject
{
    public float Speed = 1;
    public int HP = 3;
    public float ShootEnergy = 0;
    public float MaxShootEnergy = 1;
    public int Score = 1;

    public Vector2 MaxPos;
    public Vector2 MinPos;
}
