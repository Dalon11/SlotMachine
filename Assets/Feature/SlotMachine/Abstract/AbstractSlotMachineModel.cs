using System.Collections.Generic;
using UnityEngine;

namespace SlotMachine
{
    public abstract class AbstractSlotMachineModel : ScriptableObject
    {
        protected Dictionary<AllTypeSlot, AbstractSlotModel> slotDictionary;
        public Dictionary<AllTypeSlot, AbstractSlotModel> SlotDictionary => slotDictionary;

        public abstract float DurationTurn { get; }
        public abstract int CountRows { get; }
        public abstract int CountColuns { get; }

        /// <summary>
        /// Заполнение словаря.
        /// </summary>
        public abstract void InitDictionary();
    }
}