using UnityEngine;

namespace SlotMachine
{
    public class Cell
    {/// <summary>
    /// ������ �����.
    /// </summary>
    /// <param name="row">��������� Y.</param>
    /// <param name="colun">��������� X.</param>
    /// <param name="model"></param>
        public Cell(int colun, int row, AbstractSlotModel model)
        {
            this.row = row;
            this.colun = colun;
            this.model = model;
        }
        [SerializeField] private readonly int colun;
        [SerializeField] private readonly int row;
        [SerializeField] private readonly AbstractSlotModel model;

        public int Row => row;
        public int Colun => colun;
        public AbstractSlotModel Model => model;


    }
}
