using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlotMachine
{
    public abstract class AbstractSlotMachineModel : ScriptableObject
    {
        protected Dictionary<AllSlot, AbstractSlotModel> slotDictionary;
        public Dictionary<AllSlot, AbstractSlotModel> SlotDictionary => slotDictionary;

        /// <summary>
        /// Заполнение словаря.
        /// </summary>
        public abstract void InitDictionary();
    }
}