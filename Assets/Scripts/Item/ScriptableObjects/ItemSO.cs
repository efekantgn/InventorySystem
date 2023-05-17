

using UnityEngine;
using UnityEngine.UI;


public class ItemSO :ScriptableObject
{
    #region ItemSO variables

    [SerializeField] private int _itemID;
    [SerializeField] private string _itemName;
    [SerializeField] private string _itemDescription;
    [SerializeField] private bool _itemStackable;
    [SerializeField] private int _itemCount = 1;
    [SerializeField] private Sprite _itemIcon;
    [SerializeField] private ItemType _itemType;

    public string ItemName { get => _itemName; set => _itemName = value; }
    public string ItemDescription { get => _itemDescription; set => _itemDescription = value; }
    public bool ItemStackable { get => _itemStackable; set => _itemStackable = value; }
    public int ItemCount { get => _itemCount; set => _itemCount = value; }
    public Sprite ItemIcon { get => _itemIcon; set => _itemIcon = value; }
    public ItemType ItemType { get => _itemType; set => _itemType = value; }
    public int ItemID { get => _itemID; set => _itemID = value; }

    #endregion


}
public enum ItemType
{
    Equipment,
    Weapon,
    Consumable,
}
