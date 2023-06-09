using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneHanded : Weapon
{

    /// <summary>
    /// Overriding from Item
    /// It checks is item equiped and Looks CurrentOneHanded inside Intentory.
    /// And the finaly it equips, unequips or unequips equiped item and equips itself.
    /// </summary>
    public override void UseItem()
    {
        
        if (!IsEquipped && Inventory.Instance.CurrentOneHanded == null)
        {
            EquipItem(MainPanel.Instance.EquipedPanel.transform);
            UnEquipTwoHanded();
        }
        else if(IsEquipped && Inventory.Instance.CurrentOneHanded == this)
        {
            UnEquipItem(OldInventoryPanel);
        }
        else if (!IsEquipped && Inventory.Instance.CurrentOneHanded != this)
        {
            UnEquipTwoHanded();
            //UnEquip EquipedItem and equip this item
            Inventory.Instance.CurrentOneHanded.UnEquipItem(Inventory.Instance.CurrentOneHanded.OldInventoryPanel);
            EquipItem(MainPanel.Instance.EquipedPanel.transform);
            //transform.parent = OldInventoryPanel;
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
    public void UnEquipTwoHanded()
    {
        if (Inventory.Instance.CurrentTwoHand != null)
        {
            Inventory.Instance.CurrentTwoHand.UnEquipItem(Inventory.Instance.CurrentTwoHand.OldInventoryPanel);
        }

    }
}
