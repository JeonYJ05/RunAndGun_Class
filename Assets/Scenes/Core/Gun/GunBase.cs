using Core.Bullets;
using UnityEngine;

namespace Core.Gun
{
    public class GunBase : MonoBehaviour
    {
        public GameObject _bulletPrefab;
        public GameObject _firePoint;
        protected float _fireTime = 1f;

        private void FixedUpdate()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Attack();
            }
        }
        public void FireBullet()
        {
            if(_bulletPrefab != null && _firePoint != null) //&& Time.time >= _nextFireTime)
            {
                //_nextFireTime = Time.time + _fireTime;
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
            FireBullet();
        }
    }
}

