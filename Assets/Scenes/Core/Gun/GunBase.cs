using Core.Bullets;
using UnityEngine;

namespace Core.Gun
{
    public class GunBase : MonoBehaviour
    {
        [SerializeField] GameObject _bulletPrefab;
        [SerializeField] GameObject _firePoint;

        private float _lastFireTime;


        private void FixedUpdate()
        {
            transform.position = _firePoint.transform.position;
            transform.rotation = _firePoint.transform.rotation;

            Attack(0.5f);
        }
        protected void FireBullet()
        {
            if(_bulletPrefab != null && _firePoint != null)
            {
                var Bulletinstance = Instantiate(_bulletPrefab, _firePoint.transform.position, _firePoint.transform.rotation);
                Bullet bullet = Bulletinstance.GetComponent<Bullet>();
                if (bullet != null)
                {
                    bullet.Create(3, 10);
                }
            }
        }

        public virtual void Attack(float Delay)
        {
            if(Input.GetKey(KeyCode.Space) && Time.time >= _lastFireTime + Delay)
            {
                FireBullet();
                _lastFireTime = Time.time;
            }
        }
    }
}

