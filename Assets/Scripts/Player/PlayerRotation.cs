using System;
using DG.Tweening;
using Enums;
using UnityEngine;

namespace Player
{
    public class PlayerRotation : MonoBehaviour
    {
        [SerializeField] private float _rotateDuraction = 0.2f;

        private void Start()
        {
            RotateToDirection(GameSceneContext.Instance._gridSettingManager._gridSetting.GridSettingData.PlayerDirection, true);
        }

        public void RotateToDirection(TypeDirection typeDirection, bool isFast = false)
        {
            float y = 0;
            
            if (typeDirection.Equals(TypeDirection.Up))
                y = 0;
            else if (typeDirection.Equals(TypeDirection.Down))
                y = 180;
            else if (typeDirection.Equals(TypeDirection.Left))
                y = -90;
            else if (typeDirection.Equals(TypeDirection.Right))
                y = 90;

            Rotation(y, isFast);
        }
        
        private void Rotation(float y, bool isFast)
        {
            if (!isFast)
                transform.DORotate(new Vector3(0, y, 0), _rotateDuraction);
            else
                transform.localRotation = Quaternion.Euler(0, y, 0);
        }
    }
}