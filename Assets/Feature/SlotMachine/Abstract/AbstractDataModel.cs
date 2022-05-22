using UnityEngine;

namespace SlotMachine
{
    public abstract class AbstractDataModel : ScriptableObject
    {
        public abstract int PlayerMoney { get; set; }
        public abstract int PlayerBet { get; set; }
    }
}