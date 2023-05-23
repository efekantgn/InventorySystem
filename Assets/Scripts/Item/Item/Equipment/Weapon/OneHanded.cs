using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneHanded : Weapon
{

    public override void UseItem()
    {
        
        if (!IsEquipped && Inventory.Instance.CurrentOneHanded == null)
        {
            EquipItem(MainPanel.Instance.EquipedPanel.transform);
        }
        else if(IsEquipped && Inventory.Instance.CurrentOneHanded == this)
        {
            UnEquipItem(OldInventoryPanel);
        }
        else if (!IsEquipped && Inventory.Instance.CurrentOneHanded != this)
        {
            transform.parent = OldInventoryPanel;
            Debug.Log("aa");
        }

    }

    public override void EquipItem(Transform parent)
    {
        base.EquipItem(parent);
        Inventory.Instance.CurrentOneHanded = this;
    }

    public override void UnEquipItem(Transform parent)
    {
        base.UnEquipItem(parent);
        Inventory.Instance.CurrentOneHanded = null;
    }

}
