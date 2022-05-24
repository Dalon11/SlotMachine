using UnityEngine;

namespace SlotMachine
{
    public class GenerateCells
    {/// <summary>
     /// Заполняет массив ячеек слотами.
     /// </summary>
     /// <param name="cells"></param>
     /// <param name="countAllSlot"></param>
     /// <param name="model"></param>
        public GenerateCells(Cell[,] cells, int countAllSlot, AbstractSlotMachineModel model)
        {
            for (int x = 0; x < cells.GetLength(0); x++)
            {
                int firstSlot = Random.Range(0, countAllSlot);

                for (int y = 0; y < cells.GetLength(1); y++)
                {
                    if (firstSlot < 0)
                        firstSlot = countAllSlot-1;
                    cells[x, y] = new Cell(x, y, model.SlotDictionary[(AllTypeSlot)firstSlot]);
                    firstSlot--;

                    Debug.LogWarning($"x {x} y {y} price {cells[x, y].Model.PriceSlot} type {cells[x, y].Model.TypeSlot}"); // проверка
                }
            }
        }
    }
}