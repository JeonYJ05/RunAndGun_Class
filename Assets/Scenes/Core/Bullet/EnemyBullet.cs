using UnityEngine;

namespace Core.Bullets
{
    public class EnemyBullet : MonoBehaviour
    {
        [SerializeField] protected Rigidbody2D _bulletRigidBody;
        private int _damage;

        private Vector3 direction;

        private void Awake()
        {
            if (_bulletRigidBody == null)
            {
                _bulletRigidBody = GetComponent<Rigidbody2D>();
            }
        }
        public void Create(int damage, float speed)
        {
            _damage = damage;
            var dir = transform.up * speed;
            _bulletRigidBody.AddForce(dir, ForceMode2D.Impulse);
            DestroyBullet(5);
        }
        public void SpeicalCreate(int damage, float speed)
        {
            _damage = damage;
            var dir = direction * speed;    
            _bulletRigidBody.AddForce(dir, ForceMode2D.Impulse);
            DestroyBullet(5);
        }
        public void SetDirection(Vector3 dir)
        {
            direction = dir.normalized;
        }

        private void DestroyBullet(float time)
        {
            Destroy(gameObject, time);
        }
    }
}