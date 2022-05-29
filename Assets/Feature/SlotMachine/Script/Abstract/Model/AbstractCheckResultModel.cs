using UnityEngine;

namespace SlotMachine
{
    public abstract class AbstractCheckResultModel : ScriptableObject
    {
        public abstract Vector2[] CheckCells { get; }
        
        public virtual int ÑalculationWin(int priceSlot, int countSlot)
        {
            return priceSlot * (countSlot - 2);
        }
    }
}
