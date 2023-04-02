
using UnityEngine;

[CreateAssetMenu(fileName = "SOPlayerModel", menuName = "User/SOPlayerModel", order = 1)]
public class SOPlayerModel : ScriptableObject
{
    public float MaxSpeed = 1;
    public float Acceleration = 0.1f;
    public float SpeedRotation = 0.3f;
    public int HP = 10;
    public float LaserEnergy = 1;
    public float LaserPause = 5;
    public float MaxLaserScele = 3f;
    public float ShootPause = 0.5f;
    public int Livs = 2;
    public int Score = 0;
    public Vector2 MaxPos;
    public Vector2 MinPos;
}
