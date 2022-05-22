using UnityEngine;

namespace SlotMachine
{
    public abstract class AbstractCheckResult : ScriptableObject
    {
        public abstract int[] CheckRow { get; }
        public abstract int[] CheckColuns { get; }
    }
}
