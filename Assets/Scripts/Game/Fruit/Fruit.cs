using DG.Tweening;
using UnityEngine;

namespace Code
{
    public class Fruit : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _effect;
        [SerializeField] private float _targety = 2f;
        [SerializeField] private float _duraction = 0.5f;

        [field: SerializeField] public FruitType _fruitType { get; private set; }

        private Tween _animTween;

        private void Start()
        {
            _animTween = transform.DOMoveY(_targety, _duraction)
                .SetLoops(-1, LoopType.Yoyo);
        }

        public void DeactivateFruit()
        {
            Destroy(Instantiate(_effect, transform.position, Quaternion.identity), 1);
            _animTween.Kill();
            gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            _animTween.Kill();
        }
    }
}