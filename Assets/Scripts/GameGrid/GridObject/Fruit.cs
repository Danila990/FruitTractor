using DG.Tweening;
using Enums;
using UnityEngine;

namespace GameGrid.GridObject
{
    public class Fruit : MonoBehaviour
    {
        [SerializeField] private float _targety = 2f;
        [SerializeField] private float _duraction = 0.5f;
        [field: SerializeField] public TypeFruit _type { get; private set; }
        
        private Tween _animTween;

        private void OnEnable()
        {
            if (_animTween != null)
            {
                _animTween.Play();
            }
        }

        private void Start()
        {
            _animTween = transform.DOMoveY(_targety, _duraction)
                .SetLoops(-1,LoopType.Yoyo);
        }

        public void StopAnim() => _animTween.Pause();
        
        public void PlayAnim() => _animTween.Play();
        
        public void RestartAnim()
        {
            _animTween.Restart();
            _animTween.Play();
        }
        
        private void OnDisable()
        {
            _animTween.Restart();
            _animTween.Pause();
        }
    }
}