using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController
{
    private PlayerView _playerView;
    private bool _laserOn=false;
    private bool _laserIncrease = true;
    private float _scale = 1f;
    private float _scaleStep = 0.05f;
    private float _energyPart = 1f;
    private float _energyShootPart = 1f;
    private float _energyShoot = 1f;

    public FireController(PlayerView playerView)
    {
        _playerView = playerView;
        _energyPart = 1 / (_playerView.SOPlayerModel.LaserPause*30);
        _energyShootPart = 1 / (_playerView.SOPlayerModel.ShootPause * 30);
    }
    public void Execute()
    {
        if (Input.GetKeyDown(KeyCode.F)) { FireLaser(); }
        if (Input.GetKey(KeyCode.Space)) { FireBullet(); }

        if (_laserOn) 
        {
            LaserWork();
        }
        if (_playerView.SOPlayerModel.LaserEnergy < 1)
        {
            _playerView.SOPlayerModel.LaserEnergy += _energyPart;
        }
        if (_energyShoot < 1)
        {
            _energyShoot += _energyShootPart;
        }
        ShootDelay();
    }
    private void FireBullet()
    {
        if(_energyShoot>=1)
        {
            foreach (var bullet in _playerView.BulletsPool)
            {
                if (!bullet.gameObject.activeSelf)
                {
                    _energyShoot = 0;
                    bullet.Activation();
                    return;
                }
            }
        }
    }
    private void ShootDelay()
    { 
        if(_energyShoot<1)
        {
            _energyShoot += _energyShootPart;
        }
    }
    private void FireLaser()
    {
        if (_playerView.SOPlayerModel.LaserEnergy >= 1)
        {
            _playerView.SOPlayerModel.LaserEnergy = 0;
            _laserOn = true;
            _playerView.Laser.SetActive(true);
        }
    }
    private void LaserWork()
    {
        if (_laserIncrease)
        {
            if (_scale <= _playerView.SOPlayerModel.MaxLaserScele)
            {
                _scale += _scaleStep;
            }
            else
            {
                _laserIncrease = false;
            }
        }
        else 
        {
            if (_scale > 1f)
            {
                _scale -= _scaleStep;
            }
            else 
            {
                _scale = 1f;
                _laserIncrease = true;
                _laserOn = false;
                _playerView.Laser.SetActive(false);
            }
        }
        Vector3 scale =new Vector3(_scale, _playerView.Laser.transform.localScale.y,1);
        _playerView.Laser.transform.localScale= scale;
    }
}
