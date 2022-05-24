using UnityEngine;

namespace SlotMachine
{
    public abstract class AbstractCheckResultModel : ScriptableObject
    {
        public abstract Vector2[] CheckCells { get; }
    }
}
