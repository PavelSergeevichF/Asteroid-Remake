using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemysController : IExecute
{
    private EnemysView _enemysView;
    private float _uFOSpawnPause;
    private float _asteroidFullSpawnPause;
    private float _uFOSpawnPart;
    private float _asteroidFullSpawnPart;
    private float _uFOSpawnEnergy;
    private float _asteroidFullSpawnEnergy;

    public EnemysController(EnemysView enemysView)
    {
        _enemysView = enemysView;
        _uFOSpawnPause = _enemysView.SOEnemySpawn.UFOSpawnPause;
        _asteroidFullSpawnPause = _enemysView.SOEnemySpawn.AsteroidFullSpawnPause;
        _asteroidFullSpawnEnergy = 0f;
        _uFOSpawnEnergy = 0f;
        _uFOSpawnPart = 1 / (_uFOSpawnPause * 30);
        _asteroidFullSpawnPart = 1 / (_asteroidFullSpawnPause * 30); ;
        foreach (var UFO in _enemysView.UFOViews)
        {
            UFO.gameObject.GetComponent<UFOView>().Init();
            UFO.gameObject.SetActive(false);
        }
        foreach (var AsteroidFull in _enemysView.AsteroidFullViews)
        {
            AsteroidFull.gameObject.GetComponent<AsteroidFullView>().Init();
            AsteroidFull.gameObject.SetActive(false);
        }
    }

    public void Execute()
    {
        if (_uFOSpawnEnergy >= _uFOSpawnPause)
        {
            _uFOSpawnEnergy = 0f;
            SpawnUFO();
        }
        else 
        {
            _uFOSpawnEnergy += _uFOSpawnPart; 
        }

        if (_asteroidFullSpawnEnergy >= _asteroidFullSpawnPause)
        {
            _asteroidFullSpawnEnergy = 0f;
            SpawnAsteroidFull();
        }
        else
        {
            _asteroidFullSpawnEnergy += _asteroidFullSpawnPart;
        }
    }

    private void SpawnAsteroidFull()
    {
        
        foreach (var AsteroidFull in _enemysView.AsteroidFullViews)
        {
            if (!AsteroidFull.gameObject.activeSelf)
            {
                AsteroidFull.gameObject.transform.position=SetPose();
                AsteroidFull.GetComponent<AsteroidFullView>().Activation();
                AsteroidFull.gameObject.SetActive(true);
                return;
            }
        }
    }
    private void SpawnUFO()
    {
        foreach (var UFO in _enemysView.UFOViews)
        {
            if (!UFO.gameObject.activeSelf)
            {
                UFO.gameObject.transform.position = SetPose();
                UFO.GetComponent<UFOView>().Activation();
                UFO.gameObject.SetActive(true);
                return;
            }
        }
    }
    private Vector3 SetPose()
    {
        Vector3 pose = new Vector3();
        switch (Random.Range(0, 3))
        {
            case 0:
                pose = new Vector3(Random.Range(_enemysView.SOEnemySpawn.MinPos.x, _enemysView.SOEnemySpawn.MaxPos.x), _enemysView.SOEnemySpawn.MaxPos.y, 0);
                break;
            case 1:
                pose = new Vector3(Random.Range(_enemysView.SOEnemySpawn.MinPos.x, _enemysView.SOEnemySpawn.MaxPos.x), _enemysView.SOEnemySpawn.MinPos.y, 0);
                break;
            case 2:
                pose = new Vector3( _enemysView.SOEnemySpawn.MaxPos.x, Random.Range(_enemysView.SOEnemySpawn.MinPos.y, _enemysView.SOEnemySpawn.MaxPos.y), 0);
                break;
            case 3:
                pose = new Vector3(_enemysView.SOEnemySpawn.MaxPos.x, Random.Range(_enemysView.SOEnemySpawn.MinPos.y, _enemysView.SOEnemySpawn.MinPos.y), 0);
                break;
        };
        return pose;
    }
    private void SetRotation()
    { }
}
