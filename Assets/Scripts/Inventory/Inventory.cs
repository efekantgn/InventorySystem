using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    private List<Item> _items = new List<Item>();
    [SerializeField] private GameObject _UIItemElement;

    public List<Item> Items { get => _items; set => _items = value; }
    public GameObject UIItemElement { get => _UIItemElement; set => _UIItemElement = value; }

    public void AddItem(Item item)
    {
        Items.Add(item);
    }

    [ContextMenu("remove")]
    public void RemoveItem(Item item)
    {
        Items.Remove(item);
    }
    
    public void InstantiateUIElement(ItemData itemData,Transform parent)
    {
        GameObject UIGameObject = Instantiate(_UIItemElement, parent);
        Item tmp = UIGameObject.GetComponent<Item>();
        tmp.itemData.ItemID = itemData.ItemID;
        tmp.itemData.ItemName = itemData.ItemName;
        tmp.itemData.ItemDescription = itemData.ItemDescription;
        tmp.itemData.ItemStackable = itemData.ItemStackable;
        tmp.itemData.ItemCount = itemData.ItemCount;
        tmp.itemData.ItemIcon = itemData.ItemIcon;
        tmp.UpdateUIElements();
        AddItem(tmp);
    }

    




}
