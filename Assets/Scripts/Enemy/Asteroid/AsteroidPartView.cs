using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidPartView : EnemyBaseView
{
    [SerializeField] private SOPlayerModel _sOPlayerModel;
    [SerializeField] private SOEnemyBase _sO_AsteroidFull;

    private AsteroidPartController _asteroidPartController;
    public SOPlayerModel SOPlayerModel => _sOPlayerModel;
    public SOEnemyBase SOEnemyBase => _sO_AsteroidFull;

    public void Init()
    {
        _asteroidPartController = new AsteroidPartController(this);
    }
    private void FixedUpdate() => _asteroidPartController.Execute();
    public void DestroyView() => _asteroidPartController.DestroyView();
    private void OnCollisionEnter2D(Collision2D collision)
    {
        _asteroidPartController.CollisionGO(collision);
    }
    public void DeliteGameObject()
    {
        Destroy(this.gameObject);
    }
}
