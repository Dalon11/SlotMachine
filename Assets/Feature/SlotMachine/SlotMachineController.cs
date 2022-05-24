using System;
using UnityEngine;

namespace SlotMachine
{
    public class SlotMachineController : AbstractSlotMachineController
    {
        private Cell[,] cells;

        private int countAllSlot;
        private float curentDurationTurn;

        private void Awake()
        {
            model.InitDictionary();
            view.Init(dataModel);
            countAllSlot = Enum.GetValues(typeof(AllTypeSlot)).Length - 1;
            cells = new Cell[model.CountRows, model.CountColuns];
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
        protected override void GenerateSlots() => new GenerateCells(cells, countAllSlot, model);
        private void TurnDuration()
        {
            if (!dataModel.IsTurn)
                return;
            if (!TimerTurn(ref curentDurationTurn))
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
            var winModels = new AbstractSlotModel[checkModels.Length];
            var countWin = 0;

            for (int i = 0; i < checkModels.Length; i++)
            {
                for (int g = 0; g < model.CountColuns - 1; g++)
                {
                    var curentVector = checkModels[i].CheckCells[g];
                    var nextVector = checkModels[i].CheckCells[g + 1];
                    var isWin = cells[(int)curentVector.x, (int)curentVector.y].Model.TypeSlot ==
                        cells[(int)nextVector.x, (int)nextVector.y].Model.TypeSlot;

                    if (isWin)
                        winModels[i] = cells[(int)curentVector.x, (int)curentVector.y].Model;
                    else
                    {
                        winModels[i] = null;
                        break;
                    }
                }
                if (winModels[i] != null)
                {
                    countWin++;
                    Win(winModels);
                }
            }
            if (countWin == 0)
                Lose();
            dataModel.IsTurn = false;
        }
        private void Win(AbstractSlotModel[] model)
        {
            foreach (var slot in model)
            {
                var winAmount = slot.PriceSlot * dataModel.PlayerBet;
                view.WinView(winAmount);
                dataModel.PlayerMoney += winAmount;
            }
        }
        private void Lose()
        {
            view.LoseView();
            dataModel.PlayerMoney -= dataModel.PlayerBet;
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

        private bool TimerTurn(ref float duration)
        {
            if (duration <= 0)
                return false;
            duration -= Time.deltaTime;
            return true;
        }
    }
}