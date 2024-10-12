using UnityEngine;

namespace Core.Pawns
{
    public class PawnsMovement : MonoBehaviour
    {
        [SerializeField] private float _speed = 3.0f;
        [SerializeField] private Rigidbody2D _rigidbody;

        public Rigidbody2D Rigidbody => _rigidbody; 

        public void Movement(Vector2 axis)
        {
            var h = axis.x * _speed * Time.deltaTime;
            var v = axis.y * _speed * Time.deltaTime;

            Rigidbody.MovePosition(Rigidbody.position + new Vector2(h, v));
        }

        public void Rotate(Vector2 point)
        {
            Rigidbody.MoveRotation(Utility.Euler2D(transform.position, point));
        }
    }
}