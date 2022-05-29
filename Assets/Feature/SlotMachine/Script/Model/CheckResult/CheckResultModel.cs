using UnityEngine;

namespace SlotMachine
{
    [CreateAssetMenu(fileName = nameof(CheckResultModel), menuName = "Dataset/SlotMachine/" + nameof(CheckResultModel))]
    public class CheckResultModel : AbstractCheckResultModel
    {
        [Header("Настройка проверки выйгрыша.(Левый верхний угол 0.0)")]
        [Tooltip("Только целые значения.")]
        [SerializeField] private Vector2[] checkCells;

        private void OnEnable()
        {
            for (int i = 0; i < checkCells.Length; i++)
            {
                checkCells[i].x = Mathf.FloorToInt(checkCells[i].x);
                checkCells[i].y = Mathf.FloorToInt(checkCells[i].y);
            }
        }
        public override Vector2[] CheckCells => checkCells;
    }
}