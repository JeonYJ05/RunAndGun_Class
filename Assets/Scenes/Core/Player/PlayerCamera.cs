
using UnityEngine;

namespace Core.Pawns.Player
{
    public class PlayerCamera : MonoBehaviour
    {

        [SerializeField] private Transform _target;
        [SerializeField] private float _delta = 0.025f;

        private void LateUpdate()
        {
            var position = _target.position; 
            
            // ���� ���� ,  ���� ����
            var lerp = Vector3.Slerp(transform.position, position, _delta);

            transform.position = lerp;
        }
    }
}