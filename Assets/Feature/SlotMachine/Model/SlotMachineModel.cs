using System;
using System.Linq;
using UnityEngine;

namespace SlotMachine
{
    [CreateAssetMenu(fileName = nameof(SlotMachineModel), menuName = "Dataset/SlotMachine/" + nameof(SlotMachineModel))]
    public class SlotMachineModel : AbstractSlotMachineModel
    {
        [Serializable]
        private class Slot
        {
            public AllSlot status;
            public AbstractSlotModel statusBlock;
        }
        [Tooltip("Типы слотов.")]
        [SerializeField] private  Slot[] slots;

        public override void InitDictionary() => slotDictionary = slots.ToDictionary(key => key.status, value => value.statusBlock);
    }
}