using UnityEngine;

namespace SlotMachine
{
    public class Generate
    {
        /// <summary>
        /// ????????? ?????? ????? ???????.
        /// </summary>
        /// <param name="cells"></param>
        /// <param name="countAllSlot"></param>
        /// <param name="model"></param>
        public void Cell(Cell[,] cells, int countAllSlot, AbstractSlotMachineModel model)
        {
            for (int x = 0; x < cells.GetLength(0); x++)
            {
                int firstSlot = Random.Range(0, countAllSlot);
                for (int y = 0; y < cells.GetLength(1); y++)
                {
                    if (firstSlot < 0)
                        firstSlot = countAllSlot - 1;
                    cells[x, y] = new Cell(x, y, model.SlotDictionary[(AllTypeSlot)firstSlot]);
                    firstSlot--;
                }
            }
        }
    }
}