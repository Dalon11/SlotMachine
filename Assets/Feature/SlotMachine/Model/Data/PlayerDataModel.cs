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
        private readonly bool defaultIsTurn;

        private void OnEnable()
        {
            PlayerMoney = defaultPlayerMoney;
            PlayerBet = defaultPlayerBet;
            IsTurn = defaultIsTurn;
        }

        public override event Action<int> onChangePlayerMoneyText = delegate { };

        private int playerMoney;
        public override int PlayerMoney
        {
            get => playerMoney;
            set
            {
                playerMoney = Mathf.Clamp(value, 0, int.MaxValue);
                onChangePlayerMoneyText.Invoke(playerMoney);
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
                onChangePlayerBetText.Invoke(playerBet);
            }
        }
        private bool isTurn;
        public override bool IsTurn { get => isTurn; set=> isTurn=value; }

        public override bool CanTurn => !IsTurn && playerBet > 0 && (playerMoney - playerBet) >= 0;

    }
}