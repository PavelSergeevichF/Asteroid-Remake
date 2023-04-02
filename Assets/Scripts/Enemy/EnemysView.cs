using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemysView : MonoBehaviour
{
    [SerializeField] private SOEnemySpawn _sOEnemySpawn;
    [SerializeField] private List<AsteroidFullView> _asteroidFullViews= new List<AsteroidFullView>();
    [SerializeField] private List<UFOView> _uFOViews= new List<UFOView>();

    public SOEnemySpawn SOEnemySpawn => _sOEnemySpawn;
    public List<AsteroidFullView> AsteroidFullViews => _asteroidFullViews;
    public List<UFOView> UFOViews => _uFOViews;
}
