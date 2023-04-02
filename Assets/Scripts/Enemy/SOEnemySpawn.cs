using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SOEnemySpawn", menuName = "Enemy/SOEnemySpawn", order = 1)]
public class SOEnemySpawn : ScriptableObject
{
    public float UFOSpawnPause = 8f;
    public float AsteroidFullSpawnPause = 4f;
    public Vector2 MaxPos;
    public Vector2 MinPos;
}
