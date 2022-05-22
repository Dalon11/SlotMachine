using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlotMachine
{
    public abstract class AbstractSlotMachineView : MonoBehaviour
    {

        public abstract void StartTurn();
        public abstract void Bet();
        public abstract void Win(int price);
        public abstract void Lose(int bet);
    }
}