using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : IDestroy
{
    private BulletView _bullet;
    private MoveController _moveController;

    private bool _active=false;

    public BulletController(BulletView bullet) 
    {
        _bullet = bullet;
        _bullet.gameObject.SetActive(false);
        _moveController = new MoveController(bullet.gameObject);
    }

    public void Execute()
    {
        if (_active)
        {
            Move();
        } 
    }

    private void Move()
    {
        _moveController.MovingForward(_bullet.SOBullet.Speed);
        if (
            _bullet.gameObject.transform.position.x > _bullet.SOBullet.MaxPos.x ||
            _bullet.gameObject.transform.position.x < _bullet.SOBullet.MinPos.x ||
            _bullet.gameObject.transform.position.y > _bullet.SOBullet.MaxPos.y ||
            _bullet.gameObject.transform.position.y < _bullet.SOBullet.MinPos.y 
            )
        {
            DestroyView();
        }
    }

    public void Activation() 
    {
        _active = true;
        _bullet.gameObject.SetActive(true);
        _bullet.gameObject.transform.position = _bullet.Player.GetComponent< PlayerView >().Spawnpoint.transform.position;
        _bullet.gameObject.transform.rotation = _bullet.Player.transform.rotation;

    }

    public void DestroyView()
    {
        _active = false;
        _bullet.gameObject.SetActive(false);
    }
}
