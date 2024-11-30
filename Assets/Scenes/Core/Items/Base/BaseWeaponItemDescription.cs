using UnityEngine;

namespace YeonYJ.Core.Items
{
    public abstract class BaseWeaponItemDescription : IBaseItemDescription
    {
        public abstract string SpriteName { get; }
        public ItemType Type => ItemType.Weapon;

        public abstract float Damage { get; }
        public abstract float FireRate { get; }
        public abstract int BulletCount { get; }

        public Sprite GetSprite => Resources.Load<Sprite>($"{ItemType.Weapon}/{SpriteName}");
    }
}
