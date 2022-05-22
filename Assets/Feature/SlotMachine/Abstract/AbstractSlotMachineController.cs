using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlotMachine
{
    public abstract class AbstractSlotMachineController : MonoBehaviour
    {
        [SerializeField] protected AbstractSlotMachineView view;
        [SerializeField] protected AbstractDataModel dataModel;
        [SerializeField] protected AbstractSlotMachineModel model;
        [Tooltip("������ �������� ��������.")]
        [SerializeField] protected AbstractCheckResult[] checkModels;



    }
}