using UnityEngine;

namespace Core.Gun
{
    public class NormalGun : GunBase
    {
      

        private void Start()
        {
            _fireTime = 0.5f;
        }
        public override void Attack()
        {
          base.Attack();
        }

        
    }
}