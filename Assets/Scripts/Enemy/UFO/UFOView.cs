using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOView : EnemyBaseView
{
    [SerializeField] private GameObject _player;
    [SerializeField] private SOEnemyBase _sO_UFO;

    private UFOController _uFOController;

    public SOEnemyBase SOEnemyBase =>_sO_UFO;

    public void Init()
    {
        _uFOController = new UFOController(this, _player);
    }

    private void FixedUpdate() => _uFOController.Execute();
    public void Activation() => _uFOController.Activation();
    public void DestroyView() => _uFOController.DestroyView();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _uFOController.CollisionGO(collision);
    }
}
