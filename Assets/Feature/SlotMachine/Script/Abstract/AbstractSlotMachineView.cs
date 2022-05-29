using UnityEngine;

namespace SlotMachine
{
    public abstract class AbstractSlotMachineView : MonoBehaviour
    {
        public abstract void Init(AbstractDataModel dataModel, AbstractSlotMachineModel model);
        public abstract void WinView(int count);
        public abstract void LoseView();


    }
}