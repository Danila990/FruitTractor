using UnityEngine;

namespace Player
{
    public class WheelAnimation : MonoBehaviour
    {
        [SerializeField] private Transform[] _wheels;
        [SerializeField] private float rotationSpeed = 30f;

        private PlayerMovement _playerMovement;

        private void Start()
        {
            _playerMovement = GetComponent<PlayerMovement>();
        }

        private void Update()
        {
            if(!_playerMovement._isMove) return;
            
            foreach (Transform wheel in _wheels)
            {
                wheel.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
            }
        }
    }
}