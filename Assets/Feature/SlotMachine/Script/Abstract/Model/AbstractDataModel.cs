using System;
using UnityEngine;

namespace SlotMachine
{
    public abstract class AbstractDataModel : ScriptableObject
    {
        public abstract event Action<int> onChangePlayerMoneyText;
        public abstract int PlayerMoney { get; set; }

        public abstract event Action<int> onChangePlayerBetText;
        public abstract int PlayerBet { get; set; }
        public abstract int MinPlayerBet { get; set; }

        public abstract bool IsTurn { get; set; }
        public abstract bool CanTurn { get; }
        public abstract bool IsGameOver { get; }
    }
}