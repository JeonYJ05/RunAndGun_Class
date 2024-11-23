using UnityEngine;

namespace Core.Gun
{
    public class NormalGun : GunBase
    {
        [SerializeField] float _nextFireTime = 1f; 

        private void Start()
        {
            _fireTime = 0.5f;
        }
        public override void Attack()
        {
            if (Time.time >= _nextFireTime)
            {
                _nextFireTime = Time.time + _fireTime;
                base.Attack();
            }
        }

        
    }
}