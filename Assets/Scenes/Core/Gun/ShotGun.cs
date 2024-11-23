using Core.Bullets;
using Core.Gun;
using UnityEngine;

public class ShotGun : GunBase
{

    [SerializeField] float _spreadAngle = 15f; // 샷건의 발사 각도
    [SerializeField] float _coolTime = 2f;
    [SerializeField] int _bulletSpeed = 10;
    [SerializeField] int _bulletCount = 3; // 발사할 총알 수
    [SerializeField] float _nextFireTime = 2f;
    [SerializeField] float _fireRate = 0.5f;
    public override void Attack()
    {
        ShotGunAttack();
    }

    protected void ShotGunAttack()
    {
        float halfSpreadAngle = _spreadAngle / 2;

        if (Time.time >= _nextFireTime)
        {
            _nextFireTime = Time.time + _fireRate;  
            for (int i = 0; i < _bulletCount; ++i)
            {
                float angle = -halfSpreadAngle + (i * _spreadAngle / (_bulletCount - 1));
                Vector3 bulletDirection = Quaternion.Euler(0, 0, angle) * transform.up;

                Vector3 SpawnPosition = _firePoint.transform.position;

                GameObject bulletInstance = Instantiate(_bulletPrefab, SpawnPosition, Quaternion.identity);
                Bullet bullet = bulletInstance.GetComponent<Bullet>();
                if (bullet != null)
                {
                    bullet.SetDirection(bulletDirection);
                    bullet.SpeicalCreate(3, _bulletSpeed);
                }
            }
        }
    }

}