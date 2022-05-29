using UnityEngine;

namespace SlotMachine
{
    public class AnimationSlotMachineView : AbstractAnimationSlotMachineView
    {
        private Animator animator;
        private AllTypeSlot typeSlot = AllTypeSlot.Null;

        private void Awake() => animator = GetComponent<Animator>();
        private void Start() => animator.speed = 0;

        public override void AnimationPlay() => animator.speed = 1;
        public override void AnimationStop(Cell cellX) => typeSlot = cellX.Model.TypeSlot;
        /// <summary>
        /// Ивент остановки анимации.
        /// </summary>
        /// <param name="typeSlot">Ключ ивента.</param>
        public void AnimationStopEvent(AllTypeSlot typeSlot)
        {
            if (this.typeSlot == typeSlot)
            {
                animator.speed = 0;
                this.typeSlot = AllTypeSlot.Null;
            }
        }
    }
}