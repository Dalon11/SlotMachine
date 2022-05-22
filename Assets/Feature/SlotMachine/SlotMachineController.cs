using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlotMachine
{
    public class SlotMachineController : AbstractSlotMachineController
    {
        [SerializeField] private int countRows;
        [SerializeField] private int countColuns;

        private Cell[,] cells;

        private int countSlot;

        private void Awake()
        {
            model.InitDictionary();
            countSlot = Enum.GetValues(typeof(AllSlot)).Length;
            cells = new Cell[countRows, countColuns];
        }
        private void Start()
        {

        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
                StartTurn();
        }
        public void StartTurn()
        {
            if (dataModel.PlayerMoney - dataModel.PlayerBet >= 0)
            {
                view.StartTurn();
                GenerateSlot();
            }
        }
        private void GenerateSlot()
        {
            for (int y = 0; y < countColuns; y++)
            {
                var firstSlot = UnityEngine.Random.Range(0, countSlot);

                for (int x = 0; x < countRows; x++)
                {
                    if (firstSlot >= countSlot)
                        firstSlot = 0;

                    var cell = new Cell(x, y, GenerateSlot((AllSlot)firstSlot));
                    firstSlot++;
                    cells[x, y] = cell;
                    print($"x {x} y {y} price {cells[x, y].Model.PriceSlot}"); // проверка
                }
            }
            ResultTurn();
        }
        private void ResultTurn()
        {
            var isWin = false;
            var countWin = 0;
            var winModels = new AbstractSlotModel[checkModels.Length];

            for (int i = 0; i < checkModels.Length; i++)
            {
                for (int j = 0; j < countColuns - 1; j++)
                {
                    isWin = cells[checkModels[i].CheckRow[j], checkModels[i].CheckColuns[j]].Model.TypeSlot ==
                      cells[checkModels[i].CheckRow[j + 1], checkModels[i].CheckColuns[j + 1]].Model.TypeSlot;

                    if (isWin)
                        winModels[i] = cells[checkModels[i].CheckRow[j], checkModels[i].CheckColuns[j]].Model;
                    else
                    {
                        winModels[i] = null;
                        break;
                    }
                }
                if (isWin)
                {
                    print(isWin);       //check
                    countWin++;
                    Win(winModels);
                }
            }
            if (countWin <= 0)
                Lose();
        }
        private void Win(params AbstractSlotModel[] model)
        {
            foreach (var item in model)
            {
                view.Win(item.PriceSlot);
                dataModel.PlayerMoney = item.PriceSlot * dataModel.PlayerBet;
            }
        }
        private void Lose()
        {
            view.Lose(dataModel.PlayerBet);
            dataModel.PlayerMoney -= dataModel.PlayerBet;
        }

        private AbstractSlotModel GenerateSlot(AllSlot slot) => model.SlotDictionary[slot];
    }
}