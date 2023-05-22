using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : Armor
{

    public override void UseItem()
    {
        base.UseItem();
        if (!IsEquipped)
        {
            Inventory.Instance.CurrentBody= this;
            IsEquipped = true;
        }
        else
        {
            Inventory.Instance.CurrentBody = null;
            IsEquipped = false;
        }

    }
}
