using DG.Tweening;
using UnityEngine;

namespace Code
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _moveDuraction;
        
        private Tween _moveTween;
        private Cell _targetCell;

        public bool IsMove => _moveTween != null && _moveTween.active;

        public void Move(Cell targetCell)
        {
            if (IsMove)
            {
                return;
            }

            _targetCell = targetCell;
            _moveTween = transform.DOMove(targetCell.transform.position, _moveDuraction)
                .SetEase(Ease.Linear)
                .OnComplete(OnMoveComplete);
        }

        private void OnMoveComplete()
        {
            _moveTween.Kill();
            _targetCell.CellEvent();
        }
    }
}