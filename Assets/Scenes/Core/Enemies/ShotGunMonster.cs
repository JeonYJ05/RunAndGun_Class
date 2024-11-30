using Core.Bullets;
using System.Collections;
using UnityEngine;


public class ShotGunMonster : Monster
{
    [SerializeField] float _spreadAngle = 15f; // 샷건의 발사 각도
    [SerializeField] int _bulletCount = 3; // 발사할 총알 수
    [SerializeField] float _coolTime = 2f;
    [SerializeField] float _bulletSpeed = 10.0f;
    private void Start()
    {
        CurrentHealth += 20;
    }

    public override void Attack()
    {
        ShotGunAttack();
    }

    protected void ShotGunAttack()
    {
        float halfSpreadAngle = _spreadAngle / 2;

        if (Time.time > _nextFireTime)
        {
            _nextFireTime = Time.time + _coolTime;
            for (int i = 0; i < _bulletCount; ++i)
            {
                float angle = -halfSpreadAngle + (i * _spreadAngle / (_bulletCount - 1));
                Vector3 bulletDirection = Quaternion.Euler(0, 0, angle) * transform.up;

                Vector3 SpawnPosition = _firePoint.position;

                GameObject bulletInstance = Instantiate(_bulletPrefab, SpawnPosition, Quaternion.identity);
                EnemyBullet Ebullet = bulletInstance.GetComponent<EnemyBullet>();
                if (Ebullet != null)
                {
                    Ebullet.SetDirection(bulletDirection);
                    Ebullet.SpeicalCreate(3, _bulletSpeed);
                }
            }
        }
    }

   
}