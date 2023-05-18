using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Variables
    [SerializeField] private List<Item> _items = new List<Item>();
    [SerializeField] private List<Item> _equipedItems = new List<Item>();
    [SerializeField] private GameObject _UIItemElement;

    public List<Item> Items { get => _items; set => _items = value; }
    public GameObject UIItemElement { get => _UIItemElement; set => _UIItemElement = value; }
    public List<Item> EquipedItems { get => _equipedItems; set => _equipedItems = value; }

    #endregion

    #region Instance

    private static Inventory _instance;
    public static Inventory Instance { get => _instance; set => _instance = value; }

    private void Awake()
    {
        if (Instance == null || Instance != this)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    #endregion


    #region AddItemWithTheirData
    public void AddItem(HeadData itemData,Transform parent) 
    {
        if (InventoryHasItem(itemData) && itemData.ItemStackable)
        {
            FindItemInInventory(itemData).IncreaseItemCount(itemData.ItemCount);
        }
        else
        {
            InstantiateUIElement(itemData, parent);
            
        }
    }

    public void AddItem(BodyData itemData, Transform parent)
    {
        if (InventoryHasItem(itemData) && itemData.ItemStackable)
        {
            FindItemInInventory(itemData).IncreaseItemCount(itemData.ItemCount);
        }
        else
        {
            InstantiateUIElement(itemData, parent);
        }
    }

    public void AddItem(FootData itemData, Transform parent)
    {
        if (InventoryHasItem(itemData) && itemData.ItemStackable)
        {
            FindItemInInventory(itemData).IncreaseItemCount(itemData.ItemCount);
        }
        else
        {
            InstantiateUIElement(itemData, parent);
        }
    }

    public void AddItem(ConsumableData itemData, Transform parent)
    {
        if (InventoryHasItem(itemData) && itemData.ItemStackable)
        {
            FindItemInInventory(itemData).IncreaseItemCount(itemData.ItemCount);
        }
        else
        {
            InstantiateUIElement(itemData, parent);
        }
    }

    public void AddItem(OneHandedData itemData, Transform parent)
    {
        if (InventoryHasItem(itemData) && itemData.ItemStackable)
        {
            FindItemInInventory(itemData).IncreaseItemCount(itemData.ItemCount);
        }
        else
        {
            InstantiateUIElement(itemData, parent);
        }
    }

    public void AddItem(TwoHandedData itemData, Transform parent)
    {
        if (InventoryHasItem(itemData) && itemData.ItemStackable)
        {
            FindItemInInventory(itemData).IncreaseItemCount(itemData.ItemCount);
        }
        else
        {
            InstantiateUIElement(itemData, parent);
        }
    }

    public void AddItem(OffHandData itemData, Transform parent)
    {
        if (InventoryHasItem(itemData) && itemData.ItemStackable)
        {
            FindItemInInventory(itemData).IncreaseItemCount(itemData.ItemCount);
        }
        else
        {
            InstantiateUIElement(itemData, parent);
        }
    }

    #endregion

    public void AddItem(Item item)
    {
        Items.Add(item);
    }



    [ContextMenu("remove")]
    public void RemoveFirstItem()
    {
        Destroy(Items[0].gameObject);
        Items.Remove(Items[0]);
    }
    public void RemoveItem(Item item)
    {
        Destroy(item.gameObject);
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


    #region ItemsListDataChecks
    public bool InventoryHasItem(ItemData itemData)
    {
        foreach (var item in Items)
        {
            if(item.itemData.ItemID==itemData.ItemID)
                return true;
        }

        return false;
    }

    public Item FindItemInInventory(ItemData itemData)
    {

        foreach (var item in Items)
        {
            if (item.itemData.ItemID == itemData.ItemID)
                return item;
        }
        return null;

    }
    #endregion

    #region EquipedItemsOperations

    public void AddToEquipedList(Item item)
    {
        EquipedItems.Add(item);
    }

    public void RemoveFromEquipedList(Item item)
    {
        EquipedItems.Remove(item);
    }


    #endregion
}
