using System;
using UnityEngine;

namespace SlotMachine
{
    [CreateAssetMenu(fileName = nameof(PlayerDataModel), menuName = "Dataset/SlotMachine/" + nameof(PlayerDataModel))]
    public class PlayerDataModel : AbstractDataModel
    {
        [Tooltip("Количство денег.")]
        [SerializeField] private int defaultPlayerMoney;
        [Tooltip("Ставка.")]
        [SerializeField] private int defaultPlayerBet;


        private void OnEnable()
        {
            PlayerMoney = defaultPlayerMoney;
            PlayerBet = defaultPlayerBet;
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
                playerBet = Mathf.Clamp(value, 0, int.MaxValue);
                onChangePlayerBetText?.Invoke(playerBet);
            }
        }

        public override bool IsTurn { get; set; }
        public override bool CanTurn => !IsGameOver && !IsTurn && playerBet > 0 && (playerMoney - playerBet) >= 0;
        public override bool IsGameOver => playerMoney <= 0;
        
    }
}