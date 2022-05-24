using UnityEngine;

namespace SlotMachine
{
    public class AnimationSlotView : AbstractAnimationSlotView
    {
        private Animator animator;
        AllTypeSlot typeSlot = AllTypeSlot.Null;

        private void Awake() => animator = GetComponent<Animator>();
        private void Start() => AnimationChangeSpeed(false);

        public override void AnimationPlay() => AnimationChangeSpeed(true);
        public override void AnimationStop(Cell cellX) => typeSlot = cellX.Model.TypeSlot;
        /// <summary>
        /// Ивент остановки анимации.
        /// </summary>
        /// <param name="typeSlot">Ключ ивента.</param>
        public void AnimationStopEvent(AllTypeSlot typeSlot)
        {
            if (this.typeSlot == typeSlot)
            {
                AnimationChangeSpeed(false);
                this.typeSlot = AllTypeSlot.Null;
            }
        }
        private void AnimationChangeSpeed(bool isPlay) => animator.speed = isPlay ? 1 : 0;
    }
}