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
        public float[] TypeCell(Cell[,] cells, AbstractCheckResultModel[] checkModel, AbstractSlotMachineModel model)
        {
            var winPrices = new float[model.CountLine];
            var countTypeCellInLine = new Dictionary<AllTypeSlot, int>();

            for (int i = 0; i < model.CountLine; i++)
            {
                for (int x = 0; x < model.CountColuns; x++)
                {
                    var currentTypeCell = cells[(int)checkModel[i].CheckCells[x].x, (int)checkModel[i].CheckCells[x].y].Model.TypeSlot;

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