using UnityEngine;

namespace SlotMachine
{
    public abstract class AbstractAnimationSlotMachineView : MonoBehaviour
    {
        public abstract void AnimationPlay();
        public abstract void AnimationStop(Cell cellX);
    }
}