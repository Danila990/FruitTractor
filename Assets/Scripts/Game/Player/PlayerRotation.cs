using DG.Tweening;
using UnityEngine;

namespace Code
{
    public class PlayerRotation : MonoBehaviour
    {
        [SerializeField] private float _rotateDuraction = 0.2f;

        public void RotateToDirection(DirectionType typeDirection, bool isFast = false)
        {
            float y = 0;
            
            if (typeDirection.Equals(DirectionType.Up))
                y = 0;
            else if (typeDirection.Equals(DirectionType.Down))
                y = 180;
            else if (typeDirection.Equals(DirectionType.Left))
                y = -90;
            else if (typeDirection.Equals(DirectionType.Right))
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