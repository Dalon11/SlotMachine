using UnityEngine;

namespace SlotMachine
{
    public class Cell
    {/// <summary>
    /// Ячейка слота.
    /// </summary>
    /// <param name="row">Кордината Y.</param>
    /// <param name="colun">Кордината X.</param>
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
