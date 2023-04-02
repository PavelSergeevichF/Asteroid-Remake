
using UnityEngine;

[CreateAssetMenu(fileName = "SOBullet", menuName = "Bullet/SOBullet", order = 1)]
public class SOBullet : ScriptableObject
{
    public float Speed = 1;
    public int DMG = 1;
    public Vector2 MaxPos;
    public Vector2 MinPos;
}
