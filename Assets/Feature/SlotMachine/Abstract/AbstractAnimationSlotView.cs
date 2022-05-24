using UnityEngine;

namespace SlotMachine
{
    public abstract class AbstractAnimationSlotView : MonoBehaviour
    {
        /// <summary>
        /// Запуск анимации вращения.
        /// </summary>
        public abstract void AnimationPlay();
        /// <summary>
        /// Остановка анимации вращения.
        /// </summary>
        /// <param name="cellX">Ячейка с кординатой Y=0.</param>
        public abstract void AnimationStop(Cell cellX);
    }
}