using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private SOPlayerModel _sOPlayerModel;
    [SerializeField] private GameObject _laser;
    [SerializeField] private GameObject _spawnpoint;
    [SerializeField] private Transform _staticOBJ;
    [SerializeField] private List<BulletView> _bulletsPool;
    

    public SOPlayerModel SOPlayerModel => _sOPlayerModel;
    public GameObject Laser => _laser;
    public GameObject Spawnpoint => _spawnpoint;
    public Transform StaticOBJ => _staticOBJ;
    public List<BulletView> BulletsPool => _bulletsPool;

    public delegate void Colision();
    public event Colision Collision;

    public void CollisionEnter()
    {
        Collision?.Invoke();
    }
}