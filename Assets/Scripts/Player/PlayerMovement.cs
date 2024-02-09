using System;
using DG.Tweening;
using GameGrid.Controllers;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private const string ID_Move_ANIMATION = "IsMove";
        
        [SerializeField] private float _moveDuraction;
        
        private PlayerController _playerController;
        private bool _isMove = false;
        private Tween _moveTween;
        private WheelAnimation _wheelAnimation;

        private void Awake()
        {
            _playerController = GetComponent<PlayerController>();
            _wheelAnimation = GetComponent<WheelAnimation>();
        }

        public void MoveToTarget(Transform target)
        {
            if (_isMove) return;
            _isMove = true;
            _wheelAnimation.Play();
            
            _moveTween = transform.DOMove(target.position, _moveDuraction)
                .SetEase(Ease.Linear)
                .OnComplete(CallbackMove);
        }

        public void Restart()
        {
            _moveTween.Kill();
            _isMove = false;
            _wheelAnimation.Stop();
        }
        
        private void CallbackMove()
        {
            _wheelAnimation.Stop();
            _isMove = false;
            _playerController.MoveComplete();
        }
    }
}