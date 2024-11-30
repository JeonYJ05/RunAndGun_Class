
namespace YeonYJ.Core.Items
{
    public class ShotgunItem : BaseWeaponItemDescription
    {
        public override string SpriteName => "Shotgun";

        public override float Damage => 10;
        public override float FireRate => 0.8f;
        public override int BulletCount => 6;
    }
}
