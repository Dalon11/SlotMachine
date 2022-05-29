using System.Collections.Generic;

namespace SlotMachine
{
    public class CheckCell
    {
        /// <summary>
        /// Проверка ячеек по типу.
        /// </summary>
        /// <param name="cells"></param>
        /// <param name="checkModel"></param>
        /// <param name="countLine"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public int[] TypeCell(Cell[,] cells, AbstractCheckResultModel[] checkModel, int countLine, AbstractSlotMachineModel model)
        {
            var winPrices = new int[countLine];
            var countTypeCellInLine = new Dictionary<AllTypeSlot, int>();

            for (int i = 0; i < countLine; i++)
            {
                for (int j = 0; j < model.CountColuns; j++)
                {
                    var currentCell = checkModel[i].CheckCells[j];
                    var currentTypeCell = cells[(int)currentCell.x, (int)currentCell.y].Model.TypeSlot;
                    if (!countTypeCellInLine.ContainsKey(currentTypeCell))
                        countTypeCellInLine.Add(currentTypeCell, 0);
                    countTypeCellInLine[currentTypeCell] = ++countTypeCellInLine[currentTypeCell];
                }
                foreach (var typeCell in countTypeCellInLine)
                {
                    if (typeCell.Value >= model.MinCountSlotInWin)
                        winPrices[i] = checkModel[i].СalculationWin(model.SlotDictionary[typeCell.Key].PriceSlot, typeCell.Value);
                }
                countTypeCellInLine.Clear();
            }
            return winPrices;
        }
    }
}