using System;
using DG.Tweening;
using GameGrid.Controllers;
using Manager;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour,IInit
    {
        private const string ID_Move_ANIMATION = "IsMove";
        
        [SerializeField] private float _moveDuraction;
        
        private PlayerController _playerController;
        private Tween _moveTween;
        public bool _isMove { get; private set; } = false;

        public void Init()
        {
            _playerController = GetComponent<PlayerController>();

            GameManager gameManager = GameSceneContext.Instance._gameManager;
            gameManager.SubPauseEvent(PauseMove);
            gameManager.SubPlayEvent(PlayMove);
        }

        public void MoveToTarget(Transform target)
        {
            if (_isMove) return;
            _isMove = true;
            
            _moveTween = transform.DOMove(target.position, _moveDuraction)
                .SetEase(Ease.Linear)
                .OnComplete(CallbackMove);
        }

        public void Restart()
        {
            _moveTween.Kill();
            _isMove = false;
        }

        private void PauseMove() => _moveTween.Pause();
        
        private void PlayMove() => _moveTween.Play();
        
        private void CallbackMove()
        {
            _isMove = false;
            _playerController.MoveComplete();
        }
    }
}