using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneHanded : Weapon
{

    public override void UseItem()
    {
        base.UseItem();
        if (!IsEquipped)
        {
            Inventory.Instance.CurrentOneHanded = this;
            IsEquipped = true;
        }
        else
        {
            Inventory.Instance.CurrentOneHanded = null;
            IsEquipped = false;
        }

    }



}
