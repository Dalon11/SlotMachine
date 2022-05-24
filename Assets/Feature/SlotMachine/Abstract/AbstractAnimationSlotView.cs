using UnityEngine;

namespace SlotMachine
{
    public abstract class AbstractAnimationSlotView : MonoBehaviour
    {
        public abstract void AnimationPlay();
        public abstract void AnimationStop(Cell cellX);
    }
}