using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : Armor
{

    public override void UseItem()
    {
        
        if (!IsEquipped && Inventory.Instance.CurrentBody==null)
        {
            EquipItem(MainPanel.Instance.EquipedPanel.transform);
        }
        else if(IsEquipped && Inventory.Instance.CurrentBody == this)
        {
            UnEquipItem(OldInventoryPanel);
        }
        else if (!IsEquipped && Inventory.Instance.CurrentBody != this)
        {
            transform.SetParent(OldInventoryPanel);
        }
    }

    public override void EquipItem(Transform parent)
    {
        base.EquipItem(parent);
        Inventory.Instance.CurrentBody = this;
    }

    public override void UnEquipItem(Transform parent)
    {
        base.UnEquipItem(parent);
        Inventory.Instance.CurrentBody = null;
    }
}
