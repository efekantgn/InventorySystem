using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : Armor
{

    public override void UseItem()
    {

        if (!IsEquipped && Inventory.Instance.CurrentHead == null)
        {
            EquipItem(MainPanel.Instance.EquipedPanel.transform);
        }
        else if (IsEquipped && Inventory.Instance.CurrentHead == this)
        {
            UnEquipItem(OldInventoryPanel);
        }
        else if (!IsEquipped && Inventory.Instance.CurrentHead != this)
        {
            //UnEquip EquipedItem and equip this item
            Inventory.Instance.CurrentHead.UnEquipItem(Inventory.Instance.CurrentHead.OldInventoryPanel);
            EquipItem(MainPanel.Instance.EquipedPanel.transform);
            //transform.SetParent(OldInventoryPanel);
        }
    }


    public override void EquipItem(Transform parent)
    {
        base.EquipItem(parent);
        Inventory.Instance.CurrentHead = this;
    }

    public override void UnEquipItem(Transform parent)
    {
        base.UnEquipItem(parent);
        Inventory.Instance.CurrentHead = null;
    }

}
