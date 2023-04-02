using System.Collections.Generic;
using UnityEngine;

public class MainView : MonoBehaviour
{
    [SerializeField] private PlayerView _playerView;
    [SerializeField] private EnemysView _enemysView;
    [SerializeField] private UIView _uIView;

    private MineControllers _mineControllers;
    
    public PlayerView PlayerView => _playerView;
    public EnemysView EnemysView => _enemysView;
    public UIView UIView => _uIView;

    #region Execute
    private void Awake()
    {
        _mineControllers = new MineControllers();
        new StartScenGameInit(_mineControllers, this);

        _mineControllers.Awake();

    }

    private void Start()
    {
        _mineControllers.Init();
    }

    private void Update()
    {
        _mineControllers.Execute();
    }

    private void FixedUpdate()
    {
        _mineControllers.FixedExecute();
    }

    private void LateUpdate()
    {
        _mineControllers.LateExecute();
    }

    private void OnDestroy()
    {
        _mineControllers.Cleanup();
    }
    public void OnDestroyBetwenLevels()
    {
        _mineControllers.Cleanup();
    }
    #endregion
}
