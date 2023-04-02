using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

internal sealed class StartScenGameInit
{
    public StartScenGameInit(MineControllers controllers, MainView mainController)
    {
        PlayerController _playerController = new PlayerController(mainController.PlayerView);
        controllers.Add(_playerController);

        UIController _uIController = new UIController(mainController.UIView, mainController.PlayerView.SOPlayerModel);
        controllers.Add(_uIController);

        EnemysController _enemysController = new EnemysController(mainController.EnemysView);
        controllers.Add(_enemysController);
    }
}
