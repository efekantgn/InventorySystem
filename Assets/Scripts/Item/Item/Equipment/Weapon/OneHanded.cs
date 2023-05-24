using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneHanded : Weapon
{

    public override void UseItem()
    {
        Debug.Log("UseItem");
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
}
