using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foot : Armor
{
    public override void UseItem()
    {

        if (!IsEquipped && Inventory.Instance.CurrentFoot == null)
        {
            EquipItem(MainPanel.Instance.EquipedPanel.transform);
        }
        else if (IsEquipped && Inventory.Instance.CurrentFoot == this)
        {
            UnEquipItem(OldInventoryPanel);
        }
        else if (!IsEquipped && Inventory.Instance.CurrentFoot != this)
        {
            //UnEquip EquipedItem and equip this item
            Inventory.Instance.CurrentFoot.UnEquipItem(Inventory.Instance.CurrentFoot.OldInventoryPanel);
            EquipItem(MainPanel.Instance.EquipedPanel.transform);
            //transform.SetParent(OldInventoryPanel);
        }
    }


    public override void EquipItem(Transform parent)
    {
        base.EquipItem(parent);
        Inventory.Instance.CurrentFoot = this;
    }

    public override void UnEquipItem(Transform parent)
    {
        base.UnEquipItem(parent);
        Inventory.Instance.CurrentFoot = null;
    }
}
