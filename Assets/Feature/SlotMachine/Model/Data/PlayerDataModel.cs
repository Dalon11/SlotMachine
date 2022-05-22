using UnityEngine;

namespace SlotMachine
{
    [CreateAssetMenu(fileName = nameof(PlayerDataModel), menuName = "Dataset/SlotMachine/" + nameof(PlayerDataModel))]
    public class PlayerDataModel : AbstractDataModel
    {
        [Tooltip("Количство денег.")]
        [SerializeField] private int playerMoney;
        [Tooltip("Ставка.")]
        [SerializeField] private int playerBet;

        public override int PlayerMoney
        {
            get => playerMoney;
            set => playerMoney = Mathf.Clamp(value, 0, int.MaxValue);
        }
        public override int PlayerBet
        {
            get => playerBet;
            set => playerBet = Mathf.Clamp(value, 0, int.MaxValue);
        }
    }
}