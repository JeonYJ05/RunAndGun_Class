using Core.Gun;
using System.Collections;
using UnityEngine;

public class MuchineGun : GunBase
{
    [SerializeField] float _nextFireTime;
    [SerializeField] float _fireRate;
    [SerializeField] int _bulletCount = 3;
    [SerializeField] float _rate;
    public override void Attack()
    {
        StartCoroutine(MuchineGunAttack());
    }

    protected IEnumerator MuchineGunAttack()
    {
        if (Time.time > _nextFireTime)
        {
            _nextFireTime = Time.time + _fireRate;
            for(int i = 0; i < _bulletCount; ++i)
            {
                base.Attack();
                yield return new WaitForSeconds(_rate);
            }
        }
    }
}