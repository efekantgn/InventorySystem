using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoHanded : Weapon
{
    public override void UseItem()
    {
        
        if (!IsEquipped && Inventory.Instance.CurrentTwoHand == null)
        {
            EquipItem(MainPanel.Instance.EquipedPanel.transform);
            UnEquipOtherWeapons();
        }
        else if (IsEquipped && Inventory.Instance.CurrentTwoHand == this)
        {
            UnEquipItem(OldInventoryPanel);
        }
        else if (!IsEquipped && Inventory.Instance.CurrentTwoHand != this)
        {
            UnEquipOtherWeapons();
            //UnEquip EquipedItem and equip this item
            Inventory.Instance.CurrentTwoHand.UnEquipItem(Inventory.Instance.CurrentTwoHand.OldInventoryPanel);
            EquipItem(MainPanel.Instance.EquipedPanel.transform);
            //transform.parent = OldInventoryPanel;
        }
    }

    public override void EquipItem(Transform parent)
    {
        base.EquipItem(parent);
        Inventory.Instance.CurrentTwoHand = this;
    }

    public override void UnEquipItem(Transform parent)
    {
        base.UnEquipItem(parent);
        Inventory.Instance.CurrentTwoHand = null;
    }

    public void UnEquipOtherWeapons()
    {
        if (Inventory.Instance.CurrentOffHand != null)
        {
            Inventory.Instance.CurrentOffHand.UnEquipItem(Inventory.Instance.CurrentOffHand.OldInventoryPanel);
        }
        if (Inventory.Instance.CurrentOneHanded != null)
        {
            Inventory.Instance.CurrentOneHanded.UnEquipItem(Inventory.Instance.CurrentOneHanded.OldInventoryPanel);
        }
    }
}
