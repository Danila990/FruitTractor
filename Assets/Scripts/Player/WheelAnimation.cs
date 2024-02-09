using System;
using DG.Tweening;
using UnityEngine;

namespace Player
{
    public class WheelAnimation : MonoBehaviour
    {
        [SerializeField] private Transform[] _wheels;
        [SerializeField] private float rotationSpeed = 30f;

        private bool _isMove = false;

        public void Stop() => _isMove = false;
        public void Play() => _isMove = true;

        private void Update()
        {
            if(!_isMove) return;
            foreach (Transform wheel in _wheels)
            {
                wheel.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
            }
        }
    }
}