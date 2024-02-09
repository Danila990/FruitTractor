using System.Collections;
using TMPro;
using UnityEngine;

namespace UI.Game
{
    public class GameTimer : MonoBehaviour
    {
        [SerializeField] private TMP_Text _timerText;
        
        private int _levelTime;
        private int _currentTime;
        
        private void Start()
        {
            GameSceneContext gameSceneContext = GameSceneContext.Instance;
            
            _levelTime = gameSceneContext._gridSettingManager._gridSetting.GridSettingData.Timer;
            Restart();
            
            gameSceneContext._gameManager.SubRestartEvent(Restart);
            gameSceneContext._gameManager.SubPlayEvent(PlayGame);
            gameSceneContext._gameManager.SubPauseEvent(PauseGame);
        }
        
        private void PlayGame() => StartCoroutine(TimerCoroutine());
        private void PauseGame() => StopAllCoroutines();
        
        private IEnumerator TimerCoroutine()
        {
            while (_currentTime > 0)
            {
                yield return new WaitForSeconds(1);
                _currentTime -= 1;
                OutputTimer();
            }
            GameSceneContext.Instance._gameManager.LossEvent();
        }

        private void OutputTimer() => _timerText.text = _currentTime.ToString();

        private void Restart()
        {
            _currentTime = _levelTime;
            OutputTimer();
        }
    }
}