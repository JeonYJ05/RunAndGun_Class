using System;

namespace YeonYJ.Core.Items
{
    public class PositionItem : BaseConsumableItemDescription
    {
        public PositionItem(int count, int maxCount, Action execute)
        {
            Count = count;
            MaxCount = maxCount;
            Execute = execute;
        }

        public override string SpriteName => "Position";
        public override bool IsEmpty => Count == 0;
        public override int Count { get; set; }
        public override int MaxCount { get; }

        public override Action Execute { get; }
    }
}
