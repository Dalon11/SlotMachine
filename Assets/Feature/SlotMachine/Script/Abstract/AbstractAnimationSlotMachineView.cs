using UnityEngine;

namespace SlotMachine
{
    public abstract class AbstractAnimationSlotMachineView : MonoBehaviour
    {
        /// <summary>
        /// ������ �������� ��������.
        /// </summary>
        public abstract void AnimationPlay();
        /// <summary>
        /// ��������� �������� ��������.
        /// </summary>
        /// <param name="cellX">������ � ���������� Y=0.</param>
        public abstract void AnimationStop(Cell cellX);
    }
}