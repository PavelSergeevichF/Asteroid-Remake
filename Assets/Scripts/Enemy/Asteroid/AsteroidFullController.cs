using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using static UnityEditor.Experimental.GraphView.GraphView;

public class AsteroidFullController : IDestroy
{
    private bool _active = false;
    private float _agelSize = 1;
    private float _angel = 1;
    private float _rad = 0.5f;

    private AsteroidFullView _asteroidFullView;
    private MoveController _moveController;
    private bool _setNewVector=true;

    public AsteroidFullController(AsteroidFullView asteroidFullView)
    {
        _asteroidFullView = asteroidFullView;
        _moveController = new MoveController(_asteroidFullView.gameObject);
    }

    public void Execute()
    {
        if (_active)
        {
            Move();
            CheckPose();
        }
    }
    private void Move()
    {
        if (_setNewVector)
        {
            _setNewVector = false;
            _moveController.SetTargrt();
        }
        _moveController.MovingForwardAster(_asteroidFullView.SOEnemyBase.Speed);
    }
    public void Activation()
    {
        _active = true;
    }
    public void CollisionGO(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                {
                    collision.gameObject.GetComponent<PlayerView>().CollisionEnter();
                    DestroyView();
                }
                break;
            case "Bullet":
                {
                    collision.gameObject.GetComponent<BulletView>().DestroyView();
                    DestroyView();
                }
                break;
            case "Laser":
                {
                    DestroyView();
                }
                break;
        };
    }
    private void CheckPose()
    {
        if (_asteroidFullView.gameObject.transform.position.x > _asteroidFullView.SOEnemyBase.MaxPos.x || _asteroidFullView.gameObject.transform.position.x < _asteroidFullView.SOEnemyBase.MinPos.x)
            Destroy();
        if (_asteroidFullView.gameObject.transform.position.y > _asteroidFullView.SOEnemyBase.MaxPos.y || _asteroidFullView.gameObject.transform.position.y < _asteroidFullView.SOEnemyBase.MinPos.y)
            Destroy();
    }
    public void DestroyView()
    {
        Destroy();
        _asteroidFullView.SOPlayerModel.Score += _asteroidFullView.SOEnemyBase.Score;
        _agelSize = 360 / _asteroidFullView.AsteroidParts;
        _angel = 0;
        for (int i = 0; i < _asteroidFullView.AsteroidParts; i++)
        {
            Vector3 pos = new Vector3(
                (_asteroidFullView.transform.position.x + (Mathf.Sin(_angel / 180 * Mathf.PI) * _rad)),
                (_asteroidFullView.transform.position.y + (Mathf.Cos(_angel / 180 * Mathf.PI) * _rad)),
                0);
            _asteroidFullView.CreatAsteroidPart(pos, Quaternion.Euler(0, 0, _angel));
            _angel += _agelSize;
        }
    }
    private void Destroy()
    {
        _setNewVector = true;
        _active = false;
        _asteroidFullView.gameObject.SetActive(false);
    }
}
