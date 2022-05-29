using System;
using System.Collections.Generic;
using UnityEngine;

namespace SlotMachine
{
    public abstract class AbstractSlotMachineModel : ScriptableObject
    {
        protected Dictionary<AllTypeSlot, AbstractSlotModel> slotDictionary;
        public Dictionary<AllTypeSlot, AbstractSlotModel> SlotDictionary => slotDictionary;

        public abstract int CountRows { get; }
        public abstract int CountColuns { get; }    
        public abstract int MinCountSlotInWin { get; }
        public abstract float DurationTurn { get; }

        public abstract event Action<int> onChangeCountLine ;
        public abstract int CountLine { get; set; }

        /// <summary>
        /// Заполнение словаря.
        /// </summary>
        public abstract void InitDictionary();
    }
}