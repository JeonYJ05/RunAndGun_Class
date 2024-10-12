using UnityEngine;

namespace Core.Bullets
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] protected Rigidbody2D _bulletRigidBody;
        private int _damage;

        private void Awake()
        {
            if (_bulletRigidBody == null)
            {
                _bulletRigidBody = GetComponent<Rigidbody2D>();
            }
        }
        public void Create(int damage , int speed)
        {
            _damage = damage;
            var dir = transform.up * speed;
            _bulletRigidBody.AddForce(dir , ForceMode2D.Impulse);
            DestroyBullet(5);
        }

        private void DestroyBullet(float time)
        {
            Destroy(gameObject , time);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.TryGetComponent<Enemy>(out Enemy enemy))
            {
                Debug.Log("맞았다");
                enemy.TakeDamage(5);
                Destroy(gameObject);
            }

            if(other.gameObject.layer == LayerMask.NameToLayer("ColliderTile"))
            {
                Destroy(gameObject);
                Debug.Log("벽");
            }

        }
    }
}