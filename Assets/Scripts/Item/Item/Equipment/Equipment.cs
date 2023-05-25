using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : Item
{
    [SerializeField] private bool _isEquipped;

    public bool IsEquipped { get => _isEquipped; set => _isEquipped = value; }

    #region ClickOperations

    /// <summary>
    /// Equips Item. Also sets OldInventoryPanel
    /// </summary>
    /// <param name="parent"></param>
    public virtual void EquipItem(Transform parent)
    {
        if(transform.parent.GetComponent<InventorySlot>()!=null)
        {
            OldInventoryPanel = transform.parent;
        }
        IsEquipped= true;
        transform.SetParent(parent);
    }

    /// <summary>
    /// UnEquips Item.Also sets OldInventoryPanel to null
    /// </summary>
    /// <param name="parent"></param>
    public virtual void UnEquipItem(Transform parent)
    {
        IsEquipped= false;
        transform.SetParent(parent);
        OldInventoryPanel = null;
    }

    public override void MoveItem(Transform targetParent)
    {
        Debug.Log("MoveItem");
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
    #endregion

    



}
