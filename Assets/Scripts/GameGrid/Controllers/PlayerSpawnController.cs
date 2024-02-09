using Enums;
using Player;
using UnityEngine;

namespace GameGrid.Controllers
{
    public class PlayerSpawnController : MonoBehaviour, IInitGameSceneContext
    {
        private const string PLAYER_PATH = "Prefabs/Player";

        private PlayerController _playerController;
        private Vector3 _startPoint;
        private TypeDirection _startDirection;
        
        public void Init(GameSceneContext gameSceneContext)
        {
            _startPoint = gameSceneContext._levelGridController.GetPlayerCell().transform.position;
            _startDirection = gameSceneContext._gridSettingManager._gridSetting.GridSettingData.PlayerDirection;
            
            CreatePlayer();
            SetupPosition();
            
            gameSceneContext._gameManager.SubRestartEvent(Restart);
        }

        private void SetupPosition()
        {
            _playerController.transform.position = _startPoint;
            _playerController.GetComponent<PlayerRotation>().RotateToDirection(_startDirection, true);
        }

        private void CreatePlayer()
        {
            PlayerController loadPlayer = Resources.Load<PlayerController>(PLAYER_PATH);
            _playerController = Instantiate(loadPlayer);
        }
        
        private void Restart() => SetupPosition();
    }
}