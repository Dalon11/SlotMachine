using UnityEngine;

namespace SlotMachine
{
    public abstract class AbstractSlotModel : ScriptableObject
    {
        public abstract Sprite SpriteSlot { get; }
        public abstract int PriceSlot { get; }
        public abstract AllSlot TypeSlot { get; }
    }
}