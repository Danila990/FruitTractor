using UnityEngine;

namespace Code
{
    public class CellColor : MonoBehaviour
    {
        [SerializeField] private Color _color = Color.black;
        [SerializeField] private bool _changeColor = true;

        private void Start()
        {
            if(_changeColor)
            {
                GetComponentInChildren<MeshRenderer>().material.color = _color;
            }
        }

#if UNITY_EDITOR
        [Header("Gizmos setting"),SerializeField] Vector3 _size = new Vector3(1, 0.1f, 1);
        [SerializeField] private float _offsetY = 1f;

        private void OnDrawGizmos()
        {
            Gizmos.color = _color;
            Gizmos.DrawCube(new Vector3(transform.position.x, transform.position.y + _offsetY, transform.position.z), _size);
        }
#endif
    }
}