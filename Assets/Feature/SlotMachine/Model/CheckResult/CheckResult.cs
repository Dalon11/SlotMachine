using UnityEngine;

namespace SlotMachine
{
    [CreateAssetMenu(fileName = nameof(CheckResult), menuName = "Dataset/SlotMachine/" + nameof(CheckResult))]
    public class CheckResult : AbstractCheckResult
    {
        [Header("��������� �������� ��������.")]
        [Tooltip("��������� ������.(X)")]
        [SerializeField] private int[] �heckRow;
        [Tooltip("��������� �������.(Y)")]
        [SerializeField] private int[] �heckColun;

        public override int[] CheckRow => �heckRow;
        public override int[] CheckColuns => �heckColun;
        
    }
}