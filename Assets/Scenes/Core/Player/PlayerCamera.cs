
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
            
            // 선형 보간 ,  구면 보간
            var lerp = Vector3.Slerp(transform.position, position, _delta);

            transform.position = lerp;
        }
    }
}