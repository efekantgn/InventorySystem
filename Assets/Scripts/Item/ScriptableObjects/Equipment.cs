using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Equipment",menuName ="Items/Equipment")]
public class Equipment : ItemSO
{
    public int equipmentId;
    private void OnEnable()
    {
        EquipmentId = equipmentId;
    }

}
