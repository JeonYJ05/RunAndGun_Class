using UnityEngine;

namespace Core.Gun
{
    public class NormalGun : GunBase
    {
        private float _normalDelay = 0.5f;

        public override void Attack(float delay)
        {
            delay = _normalDelay;

            base.Attack(delay);  
        }
    }
}