using UnityEngine;

namespace SlotMachine
{
    public class Cell
    {
        public Cell(int row, int colun, AbstractSlotModel model)
        {
            this.row = row;
            this.colun = colun;
            this.model = model;
        }
        [SerializeField] private readonly int row;
        [SerializeField] private readonly int colun;
        [SerializeField] private readonly AbstractSlotModel model;

        public int Row => row;
        public int Colun => colun;
        public AbstractSlotModel Model => model;


    }
}
