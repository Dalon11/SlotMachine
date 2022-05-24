using System;
using System.Linq;
using UnityEngine;

namespace SlotMachine
{
    [CreateAssetMenu(fileName = nameof(SlotMachineModel), menuName = "Dataset/SlotMachine/" + nameof(SlotMachineModel))]
    public class SlotMachineModel : AbstractSlotMachineModel
    {
        [Header("Настроки количество столбцов и строк.")]
        [SerializeField] private int countRows;
        [SerializeField] private int countColuns;
        [Space]
        [SerializeField] private float durationTurn = 1f;

        [Serializable]
        private class Slot
        {
            public AllTypeSlot status;
            public AbstractSlotModel statusBlock;
        }
        [Header("Список слотов.")]
        [Space]
        [SerializeField] private Slot[] slots;

        public override int CountRows => countRows;
        public override int CountColuns => countColuns;
        public override float DurationTurn => durationTurn;

        public override void InitDictionary() => slotDictionary = slots.ToDictionary(key => key.status, value => value.statusBlock);
    }
}