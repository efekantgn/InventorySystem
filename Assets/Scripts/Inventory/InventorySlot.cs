using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.Progress;

public class InventorySlot : MonoBehaviour, IDropHandler
{
   
    public List<ItemData> Items=new List<ItemData>();
    public List<ItemSO> Itemso=new List<ItemSO>();
    public List<GameObject> ItemsUI = new List<GameObject>();

    public GameObject UISlotElement;
    
    public enum ItemOperation
    {
        None,
        Move,
        Remove
    }

    public void AddItem(ItemSO itemSO)
    {
        Itemso.Add(itemSO);
        ItemData tmp = ConvertToItemData(itemSO);
        AddItemToItems(tmp);

    }


    public void RemoveItem(Item item,ItemOperation itemOperation) 
    {
        RemoveItemFromInventory(item.itemData);
        RemoveItemFromItemsUI(item.gameObject, itemOperation);

    }
    public void MoveItem(Item item)
    {

        bool hasInventory = HasItemsInInventory(item.itemData);
         


        if (item.itemData.ItemStackable && hasInventory)
        {
            int ind = GetIndexOfItemFromItemUI(item.itemData);
            Items[ind].ItemCount = Items[ind].ItemCount + item.itemData.ItemCount;
            UpdateAllItemsUI();
            Destroy(item.gameObject);
        }
        else
        {
            Items.Add(item.itemData);
            ItemsUI.Add(item.gameObject);
            UpdateAllItemsUI();
        }
    }

   

    #region BackgroundListOperations
    public void AddItemToItems(ItemData itemData)
    {
        bool hasInventory = HasItemsInInventory(itemData);

        if (itemData.ItemStackable && hasInventory)
        {
            int ind = GetIndexOfItemFromInventory(itemData);
            Items[ind].ItemCount = Items[ind].ItemCount + itemData.ItemCount;
            UpdateIndexInItemsUI(ind);
        }
        else
        {
            Items.Add(itemData);
            AddItemToItemsUI(itemData);
        }
    }



    public void RemoveItemFromInventory(ItemData itemData)
    {
        Items.Remove(itemData);
    }

    

    #endregion

    #region UIListOperations

    public void AddItemToItemsUI(ItemData itemData)
    {
        GameObject go = Instantiate(UISlotElement);
        go.transform.SetParent(transform);
        go.GetComponent<Item>().SetItem(itemData);
        go.GetComponent<Item>().SetUIElements();
        ItemsUI.Add(go);
    }

    

    public void UpdateIndexInItemsUI(int ind)
    {
        ItemsUI[ind].GetComponent<Item>().SetUIElements();
    }

    public void UpdateAllItemsUI()
    {
        foreach (GameObject items in ItemsUI) 
        {
            items.GetComponent<Item>().SetUIElements();
        }
    }

    public void RemoveItemFromItemsUI(GameObject gameObject, ItemOperation itemOperation)
    {
        ItemsUI.Remove(gameObject);
        if (itemOperation==ItemOperation.Remove)
            Destroy(gameObject);
    }

    


    #endregion

    #region ScriptNeededFunctions

    

    public ItemData ConvertToItemData(ItemSO itemSO)
    {
        ItemData data = new ItemData();
        data.ItemName = itemSO.ItemName;
        data.ItemIcon = itemSO.ItemIcon;
        data.ItemDescription = itemSO.ItemDescription;
        data.ItemStackable = itemSO.ItemStackable;
        data.ItemCount = itemSO.ItemCount;
        data.ItemType= itemSO.ItemType;

        switch (itemSO.ItemType)
        {
            case ItemType.Equipment:
                data.EquipmentId = itemSO.EquipmentId;
                break;
            case ItemType.Weapon:
                data.WeaponId = itemSO.WeaponId;
                break;
            case ItemType.Consumable:
                data.ConsumableId = itemSO.ConsumableId;
                break;
            default:
                break;
        }

        return data;
    }

    public bool HasItemsInInventory(ItemData itemData)
    {
        foreach (ItemData item in Items) 
        {
            if (item.ItemName == itemData.ItemName)
            {
                return true;
            }
        }
        return false;
    }

    public int GetIndexOfItemFromInventory(ItemData itemData)
    {
        for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i].ItemName == itemData.ItemName)
            {
                return i;
            }
        }
        return -1;
    }

    public int GetIndexOfItemFromItemUI(ItemData UIItem)
    {
        for (int i = 0; i < ItemsUI.Count; i++)
        {
            if (ItemsUI[i].GetComponent<Item>().itemData.ItemName== UIItem.ItemName)
            {
                return i;
            }
        }
        return -1;

    }

    #endregion

    #region Interface
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        if (dropped.GetComponent<GUIItemMouseEvents>())
        {
            GUIItemMouseEvents item = dropped.GetComponent<GUIItemMouseEvents>();
            item.ParentAfterDrag = transform;
        }
    }

    #endregion
}
