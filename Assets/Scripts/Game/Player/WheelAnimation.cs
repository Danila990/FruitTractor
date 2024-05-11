using UnityEngine;

namespace Code
{
    public class WheelAnimation : MonoBehaviour
    {
        [SerializeField] private Transform[] _wheels;
        [SerializeField] private float rotationSpeed = 30f;
        [SerializeField] private GameObject _whellEffect;

        private PlayerMovement _playerMovement;

        private void Start()
        {
            _playerMovement = GetComponent<PlayerMovement>();
        }

        private void Update()
        {
            if (!_playerMovement.IsMove)
            {
                _whellEffect.gameObject.SetActive(false);
                return;
            }
            
            _whellEffect.gameObject.SetActive(true);
            
            foreach (Transform wheel in _wheels)
            {
                wheel.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
            }
        }
    }
}