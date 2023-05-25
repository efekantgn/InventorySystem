using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : Armor
{


    /// <summary>
    /// Overriding from Item
    /// It checks is item equiped and Looks CurrentBody inside Intentory.
    /// And the finaly it equips, unequips or unequips equiped item and equips itself.
    /// </summary>
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
            //UnEquip EquipedItem and equip this item
            Inventory.Instance.CurrentBody.UnEquipItem(Inventory.Instance.CurrentBody.OldInventoryPanel);
            EquipItem(MainPanel.Instance.EquipedPanel.transform);
            //transform.SetParent(OldInventoryPanel);
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
