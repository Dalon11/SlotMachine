using UnityEngine;

namespace SlotMachine
{
    public abstract class AbstractSlotMachineController : MonoBehaviour
    {
        [SerializeField] protected AbstractSlotMachineView view;
        [SerializeField] protected AbstractAnimationSlotMachineView[] animationViews;
        [Space]
        [SerializeField] protected AbstractDataModel dataModel;
        [SerializeField] protected AbstractSlotMachineModel model;
        [Header("Модели проверки выигрыша.")]
        [SerializeField] protected AbstractCheckResultModel[] checkResultModels;

        public abstract void StartTurn();
        protected abstract void GenerateSlots();
        protected abstract void CheckResultTurn();

    }
}