using UnityEngine;

namespace SlotMachine
{
    [CreateAssetMenu(fileName = nameof(SlotModel), menuName = "Dataset/SlotMachine/" + nameof(SlotModel))]
    public class SlotModel : AbstractSlotModel
    {
        [Header("��������� �����.")]
        [Tooltip("������ �����.")]
        [SerializeField] private Sprite spriteSlot;
        [Tooltip("��������� �����.")]
        [SerializeField] private int priceSlot;
        [Tooltip("��� �����.")]
        [SerializeField]private AllSlot typeSlot;

        public override Sprite SpriteSlot => spriteSlot;
        public override int PriceSlot => priceSlot;
        public override AllSlot TypeSlot => typeSlot;
    }

}