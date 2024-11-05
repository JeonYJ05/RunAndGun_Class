using Core.Bullets;
using UnityEngine;

namespace Core.Gun
{
    public class GunBase : MonoBehaviour
    {
        [SerializeField] GameObject _bulletPrefab;
        [SerializeField] GameObject _firePoint;
        [SerializeField] float _nextFireTime = 2f;
        protected float _fireTime = 1f;



        private void FixedUpdate()
        {
            transform.position = _firePoint.transform.position;
            transform.rotation = _firePoint.transform.rotation;

            Attack();
        }
        public void FireBullet()
        {
            if(_bulletPrefab != null && _firePoint != null && Time.time >= _nextFireTime)
            {
                _nextFireTime = Time.time + _fireTime;
                var bulletinstance = Instantiate(_bulletPrefab, _firePoint.transform.position, _firePoint.transform.rotation);
                Bullet bullet = bulletinstance.GetComponent<Bullet>();
                if (bullet != null)
                {
                    bullet.Create(3, 10);
                }
            }
        }
        public virtual void Attack()
        {
            if(Input.GetKey(KeyCode.Space))
            {
                FireBullet();
            }
        }
    }
}

