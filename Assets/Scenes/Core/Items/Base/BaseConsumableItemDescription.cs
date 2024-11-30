using System;
using UnityEngine;

namespace YeonYJ.Core.Items
{
    public abstract class BaseConsumableItemDescription : IBaseItemDescription
    {
        public abstract string SpriteName { get; }
        public ItemType Type => ItemType.Consumable;

        public abstract bool IsEmpty { get; }
        public abstract int MaxCount { get; }
        public abstract int Count { get; set; }

        public abstract Action Execute { get; }

        public Sprite GetSprite => Resources.Load<Sprite>($"{ItemType.Consumable}/{SpriteName}");
    }
}
