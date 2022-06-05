using UnityEngine;

namespace SlotMachine
{
    [CreateAssetMenu(fileName = nameof(CheckResultModel), menuName = "Dataset/SlotMachine/" + nameof(CheckResultModel))]
    public class CheckResultModel : AbstractCheckResultModel
    {
        [Header("��������� �������� ��������.(����� ������� ���� 0.0)")]
        [Tooltip("������ ����� ��������.")]
        [SerializeField] private Vector2[] checkCells;
        [Header("��� ��������� ��������.")]
        [SerializeField] private float step = 0.2f;

        private void OnEnable()
        {
            for (int i = 0; i < checkCells.Length; i++)
            {
                checkCells[i].x = Mathf.Round(checkCells[i].x);
                checkCells[i].y = Mathf.Round(checkCells[i].y);
            }
        }
        public override Vector2[] CheckCells => checkCells;

        public override float �alculationWin(int priceSlot, int countSlot) => priceSlot * countSlot * step;
    }
}