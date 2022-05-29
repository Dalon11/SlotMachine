using System;
using System.Linq;
using UnityEngine;

namespace SlotMachine
{
    [CreateAssetMenu(fileName = nameof(SlotMachineModel), menuName = "Dataset/SlotMachine/" + nameof(SlotMachineModel))]
    public class SlotMachineModel : AbstractSlotMachineModel
    {
        [Header("Количество столбцов и строк.")]
        [SerializeField] private int countRows;
        [SerializeField] private int countColuns;
        [Space]
        [Header("Количество линий выигрыйша.")]
        [SerializeField] private int minCountLine;
        [SerializeField] private int maxCountLine;
        [Space]
        [Header("Количество одинаковых слотов для выигрыша.")]
        [SerializeField] private int minCountSlotInWin;
        [Space]
        [Header("Длительность анимации кручения.")]
        [SerializeField] private float durationTurn = 1f;

        private void OnEnable()
        {
            CountLine = minCountLine;
        }


        public override int CountRows => countRows;
        public override int CountColuns => countColuns;
        public override int MinCountSlotInWin => minCountSlotInWin;
        public override float DurationTurn => durationTurn;

        public override event Action<int> onChangeCountLine = delegate { };
        private int countLine;
        public override int CountLine
        {
            get => countLine;
            set
            {
                countLine = Mathf.Clamp(value, minCountLine, maxCountLine); ;
                onChangeCountLine.Invoke(countLine);
            }
        }

        [Serializable]
        private class Slot
        {
            public AllTypeSlot status;
            public AbstractSlotModel statusBlock;
        }
        [Header("Список слотов.")]
        [Space]
        [SerializeField] private Slot[] slots;

        public override void InitDictionary() => slotDictionary = slots.ToDictionary(key => key.status, value => value.statusBlock);
    }
}