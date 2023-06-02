using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffHand : Weapon
{
    public override void UseItem()
    {

        if (!IsEquipped && Inventory.Instance.CurrentOffHand == null)
        {
            EquipItem(MainPanel.Instance.EquipedPanel.transform);
            UnEquipTwoHanded();
        }
        else if (IsEquipped && Inventory.Instance.CurrentOffHand == this)
        {
            UnEquipItem(OldInventoryPanel);
        }
        else if (!IsEquipped && Inventory.Instance.CurrentOffHand != this)
        {
            UnEquipTwoHanded();
            //UnEquip EquipedItem and equip this item
            Inventory.Instance.CurrentOffHand.UnEquipItem(Inventory.Instance.CurrentOffHand.OldInventoryPanel);
            EquipItem(MainPanel.Instance.EquipedPanel.transform);
            //transform.parent = OldInventoryPanel;
        }
    }

    public override void EquipItem(Transform parent)
    {
        base.EquipItem(parent);
        Inventory.Instance.CurrentOffHand = this;
    }

    public override void UnEquipItem(Transform parent)
    {
        base.UnEquipItem(parent);
        Inventory.Instance.CurrentOffHand = null;
    }

    public void UnEquipTwoHanded()
    {
        if (Inventory.Instance.CurrentTwoHand != null)
        {
            Inventory.Instance.CurrentTwoHand.UnEquipItem(Inventory.Instance.CurrentTwoHand.OldInventoryPanel);
        }
        
    }
}
