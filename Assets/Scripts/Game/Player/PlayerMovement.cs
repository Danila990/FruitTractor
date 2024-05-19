using DG.Tweening;
using System;
using UnityEngine;

namespace Code
{
    public class PlayerMovement : MonoBehaviour
    {
        public event Action OnMoveComplete;

        [SerializeField] private float _moveDuraction;
        
        private Tween _moveTween;
        private Cell _targetCell;
        private Transform _transform;

        public bool IsMove => _moveTween != null && _moveTween.active;

        private void Awake()
        {
            _transform = GetComponent<Transform>();
        }

        public void Move(Cell targetCell)
        {
            if (IsMove)
            {
                return;
            }

            _targetCell = targetCell;
            _moveTween = _transform.DOMove(targetCell.transform.position, _moveDuraction)
                .SetEase(Ease.Linear)
                .OnComplete(MoveComplete);
        }

        private void MoveComplete()
        {
            _moveTween.Kill();
            _targetCell.CellEvent();
            OnMoveComplete?.Invoke();
        }

        private void OnDestroy()
        {
            _moveTween?.Kill();
        }
    }
}