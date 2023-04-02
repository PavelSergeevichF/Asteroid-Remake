using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidFullView : EnemyBaseView
{
    [SerializeField] private GameObject _asteroidPartPrefab;
    [SerializeField] private SOPlayerModel _sOPlayerModel;
    [SerializeField] private SOEnemyBase _sO_AsteroidFull;
    [SerializeField] private int _asteroidParts=3;

    public GameObject AsteroidPartPrefab => _asteroidPartPrefab;

    private AsteroidFullController _asteroidFullController;
    public SOPlayerModel SOPlayerModel => _sOPlayerModel; 
    public SOEnemyBase SOEnemyBase => _sO_AsteroidFull;
    public int AsteroidParts => _asteroidParts;


    public void Init()
    {
        _asteroidFullController = new AsteroidFullController(this);
    }

    private void FixedUpdate() => _asteroidFullController.Execute();
    public void Activation() =>  _asteroidFullController.Activation();
    public void DestroyView() => _asteroidFullController.DestroyView();
    private void OnCollisionEnter2D(Collision2D collision)
    {
        _asteroidFullController.CollisionGO(collision);
    }
    public void CreatAsteroidPart(Vector3 Pos,Quaternion PosRotate)
    {
        GameObject AsteroidPart = Instantiate(AsteroidPartPrefab, Pos, PosRotate);
        AsteroidPart.GetComponent<AsteroidPartView>().Init();
    }
}
