using System;
using UnityEngine;

namespace SlotMachine
{
    [CreateAssetMenu(fileName = nameof(PlayerDataModel), menuName = "Dataset/SlotMachine/" + nameof(PlayerDataModel))]
    public class PlayerDataModel : AbstractDataModel
    {
        [Tooltip("Количство денег.")]
        [SerializeField] private int defaultPlayerMoney;
        [Tooltip("Начальная ставка.")]
        [SerializeField] private int defaultMinPlayerBet;


        private void OnEnable()
        {
            PlayerMoney = defaultPlayerMoney;
            PlayerBet = MinPlayerBet = defaultMinPlayerBet;
            IsTurn = false;
        }

        public override event Action<int> onChangePlayerMoneyText = delegate { };
        private int playerMoney;
        public override int PlayerMoney
        {
            get => playerMoney;
            set
            {
                playerMoney = Mathf.Clamp(value, 0, int.MaxValue);
                onChangePlayerMoneyText?.Invoke(playerMoney);
            }
        }

        public override event Action<int> onChangePlayerBetText = delegate { };
        private int playerBet;
        public override int PlayerBet
        {
            get => playerBet;
            set
            {
                playerBet = Mathf.Clamp(value, MinPlayerBet, PlayerMoney);
                onChangePlayerBetText?.Invoke(playerBet);
            }
        }

        private int minPlayerBet;
        public override int MinPlayerBet
        {
            get => minPlayerBet;
            set
            {
                minPlayerBet = Mathf.Clamp(value, 0, int.MaxValue);
                PlayerBet = PlayerBet;
            }
        }

        public override bool IsTurn { get; set; }
        public override bool CanTurn => !IsGameOver && !IsTurn && playerBet > 0 && (playerMoney - playerBet) >= 0;
        public override bool IsGameOver => playerMoney <= 0;

    }
}