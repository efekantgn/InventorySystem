using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : Item
{
    [SerializeField] private bool _isEquipped;

    public bool IsEquipped { get => _isEquipped; set => _isEquipped = value; }


    


    public virtual void EquipItem(Transform parent)
    {
        OldInventoryPanel = transform.parent;
        IsEquipped= true;
        transform.SetParent(parent);
    }
    public virtual void UnEquipItem(Transform parent)
    {
        IsEquipped= false;
        transform.SetParent(parent);
        OldInventoryPanel = null;
    }

    public override void MoveItem(Transform targetParent)
    {
        if (_isEquipped)
        {
            UnEquipItem(targetParent);
        }
        else
        {
            OldInventoryPanel = transform.parent;
            transform.SetParent(targetParent);

        }
    }

    public override void MoveBetweenBackpackAndPocket()
    {
        if (_isEquipped)
        {
            MoveItem(OldInventoryPanel);
        }
        else
        {
            base.MoveBetweenBackpackAndPocket();
        }
    }




}
