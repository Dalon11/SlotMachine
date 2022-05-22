using UnityEngine;

namespace SlotMachine
{
    [CreateAssetMenu(fileName = nameof(SlotModel), menuName = "Dataset/SlotMachine/" + nameof(SlotModel))]
    public class SlotModel : AbstractSlotModel
    {
        [Header("Настройки слота.")]
        [Tooltip("Спрайт слота.")]
        [SerializeField] private Sprite spriteSlot;
        [Tooltip("Стоимость слота.")]
        [SerializeField] private int priceSlot;
        [Tooltip("Тип слота.")]
        [SerializeField]private AllSlot typeSlot;

        public override Sprite SpriteSlot => spriteSlot;
        public override int PriceSlot => priceSlot;
        public override AllSlot TypeSlot => typeSlot;
    }

}