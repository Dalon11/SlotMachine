using UnityEngine;

namespace SlotMachine
{
    public abstract class AbstractSlotMachineController : MonoBehaviour
    {
        [Header("Views")]
        [SerializeField] protected AbstractSlotMachineView view;
        [SerializeField] protected AbstractAnimationSlotView[] animationViews;
        [Header("Models")]
        [SerializeField] protected AbstractDataModel dataModel;
        [SerializeField] protected AbstractSlotMachineModel model;
        [Tooltip("Модели проверки выйгрыша.")]
        [SerializeField] protected AbstractCheckResultModel[] checkModels;

        public abstract void StartTurn();
        protected abstract void GenerateSlots();
        protected abstract void CheckResultTurn();

    }
}