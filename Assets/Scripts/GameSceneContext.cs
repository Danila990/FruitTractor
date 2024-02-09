using GameGrid;
using GameGrid.Controllers;
using Manager;
using UnityEngine;

public class GameSceneContext : Singleton<GameSceneContext>
{
    [field: SerializeField] public LevelGridController _levelGridController { get; private set; }
    [field: SerializeField] public LevelGridCreator _levelGridCreator { get; private set; }
    [field: SerializeField] public InputManager _inputManager { get; private set; }
    [field: SerializeField] public GridSettingManager _gridSettingManager { get; private set; }
    [field: SerializeField] public FruitGridController _fruitGridController { get; private set; }
    [field: SerializeField] public PlayerSpawnController _playerSpawnController { get; private set; }
    [field: SerializeField] public GameManager _gameManager { get; private set; }


    protected override void Awake()
    {
        base.Awake();

        Bootstrap();
    }
    
    private void Bootstrap()
    {
        _gridSettingManager.Init();
        _inputManager.Init();
        _levelGridCreator.Init(this);
        _levelGridController.Init(this);
        _playerSpawnController.Init(this);
        _fruitGridController.Init(this);
    }
}
