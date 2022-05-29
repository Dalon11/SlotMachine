using System;
using System.Collections.Generic;
using UnityEngine;

namespace SlotMachine
{
    public class SlotMachineController : AbstractSlotMachineController
    {
        private Generate generate;
        private CheckCell check;

        private Cell[,] cells;

        private int countAllSlot;
        private float curentDurationTurn;

        private void Awake() => Init();
        private void Start()
        {            
            cells = new Cell[model.CountColuns, model.CountRows];
            countAllSlot = Enum.GetValues(typeof(AllTypeSlot)).Length - 1;
        }
        private void Update() => TurnDuration();

        public override void StartTurn()
        {
            if (dataModel.CanTurn)
            {
                curentDurationTurn = model.DurationTurn;
                dataModel.IsTurn = true;
                AnimationPlay();
                GenerateSlots();
                TurnDuration();
            }
        }
        protected override void GenerateSlots() => generate.Cell(cells, countAllSlot, model);
        private void TurnDuration()
        {
            if (!dataModel.IsTurn)
                return;
            if (!TimerTurn())
            {
                AnimationStop();
                CheckResultTurn();
            }
        }
        #region ResultGame
        /// <summary>
        /// Проверка выйгрыша.
        /// </summary>
        protected override void CheckResultTurn()
        {
            var winPrices = check.TypeCell(cells, checkResultModels, model.CountLine, model);
            var count = 0;
            foreach (var price in winPrices)
            {
                if (price > 0)
                    count++;
            }
            if (count > 0)
                Win(winPrices);
            else
                Lose();
            dataModel.IsTurn = false;
        }
        private void Win(int[] winPrices)
        {
            var winAmount = 0;
            foreach (var price in winPrices)
                winAmount += price * dataModel.PlayerBet;
            dataModel.PlayerMoney += winAmount;
            view.WinView(winAmount);
        }
        private void Lose()
        {
            dataModel.PlayerMoney -= dataModel.PlayerBet;
            view.LoseView();
        }
        #endregion

        #region Animation
        private void AnimationPlay()
        {
            foreach (var item in animationViews)
                item.AnimationPlay();
        }
        private void AnimationStop()
        {
            for (int i = 0; i < model.CountColuns; i++)
                animationViews[i].AnimationStop(cells[i, 0]);
        }
        #endregion

        private void Init()
        {
            model.InitDictionary();
            view.Init(dataModel, model);
            generate = new Generate();
            check = new CheckCell();
        }
        private bool TimerTurn()
        {
            if (curentDurationTurn <= 0)
                return false;
            curentDurationTurn -= Time.deltaTime;
            return true;
        }
    }
}