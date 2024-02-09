using System;
using DG.Tweening;
using Enums;
using UnityEngine;

namespace GameGrid.GridObject
{
    public class Fruit : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _effect;
        [SerializeField] private float _targety = 2f;
        [SerializeField] private float _duraction = 0.5f;
        [field: SerializeField] public TypeFruit _type { get; private set; }
        
        private Tween _animTween;

        private void Awake()
        {
            _animTween = transform.DOMoveY(_targety, _duraction)
                .SetLoops(-1,LoopType.Yoyo);
        }

        public void DeactivateFruit()
        {
            Destroy(Instantiate(_effect, transform.position, Quaternion.identity),1);
            _animTween.Pause();
            gameObject.SetActive(false);
        }
        
        public void RestartAnim()
        {
            _animTween.Restart();
            _animTween.Play();
        }

        private void OnDestroy()
        {
            _animTween.Kill();
        }
    }
}