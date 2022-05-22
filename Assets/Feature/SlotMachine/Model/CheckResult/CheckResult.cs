using UnityEngine;

namespace SlotMachine
{
    [CreateAssetMenu(fileName = nameof(CheckResult), menuName = "Dataset/SlotMachine/" + nameof(CheckResult))]
    public class CheckResult : AbstractCheckResult
    {
        [Header("Íàñòðîéêà ïðîâåðêè âûéãðûøà.")]
        [Tooltip("Êîðäèíàòà ñêðîêè.(X)")]
        [SerializeField] private int[] ñheckRow;
        [Tooltip("Êîðäèíàòà ñòîëáöà.(Y)")]
        [SerializeField] private int[] ñheckColun;

        public override int[] CheckRow => ñheckRow;
        public override int[] CheckColuns => ñheckColun;
        
    }
}