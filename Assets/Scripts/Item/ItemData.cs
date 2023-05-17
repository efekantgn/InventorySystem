using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData 
{

    #region ItemData variables

    private string _itemName;
    private string _itemDescription;
    private bool _itemStackable;
    private int _itemCount;
    private Sprite _itemIcon;
    private ItemType _itemType;

    public string ItemName { get => _itemName; set => _itemName = value; }
    public string ItemDescription { get => _itemDescription; set => _itemDescription = value; }
    public bool ItemStackable { get => _itemStackable; set => _itemStackable = value; }
    public int ItemCount { get => _itemCount; set => _itemCount = value; }
    public Sprite ItemIcon { get => _itemIcon; set => _itemIcon = value; }
    public ItemType ItemType { get => _itemType; set => _itemType = value; }

    #endregion

    #region Weapon Variables

    private int _weaponId;
    public virtual int WeaponId { get => _weaponId; set => _weaponId = value; }

    #endregion

    #region Equipment Variables

    private int _equipmentId;
    public virtual int EquipmentId { get => _equipmentId; set => _equipmentId = value; }

    #endregion

    #region Consumable Variables

    private int _consumableId;
    public virtual int ConsumableId { get => _consumableId; set => _consumableId = value; }


    #endregion

}
