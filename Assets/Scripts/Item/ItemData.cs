using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData 
{

    #region ItemData variables

    private int _itemID;
    private string _itemName;
    private string _itemDescription;
    private bool _itemStackable;
    private int _itemCount;
    private Sprite _itemIcon;
    private ItemType _itemType;

    public int ItemID { get => _itemID; set => _itemID = value; }
    public string ItemName { get => _itemName; set => _itemName = value; }
    public string ItemDescription { get => _itemDescription; set => _itemDescription = value; }
    public bool ItemStackable { get => _itemStackable; set => _itemStackable = value; }
    public int ItemCount { get => _itemCount; set => _itemCount = value; }
    public Sprite ItemIcon { get => _itemIcon; set => _itemIcon = value; }
    public ItemType ItemType { get => _itemType; set => _itemType = value; }

    #endregion



}
