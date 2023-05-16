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
        RemoveItemFromInventory(item.ItemData);
        RemoveItemFromItemsUI(item.gameObject, itemOperation);

    }
    public void MoveItem(Item item)
    {
        bool hasInventory = HasItemsInInventory(item.ItemData);

        if (item.ItemData.Stackable && hasInventory)
        {
            int ind = GetIndexOfItemFromItemUI(item.gameObject);
            Items[ind].Count = Items[ind].Count + item.ItemData.Count;
            UpdateAllItemsUI();
        }
        else
        {
            Items.Add(item.ItemData);
            ItemsUI.Add(item.gameObject);
            UpdateAllItemsUI();
        }
    }

    #region BackgroundListOperations
    public void AddItemToItems(ItemData itemData)
    {
        bool hasInventory = HasItemsInInventory(itemData);

        if (itemData.Stackable && hasInventory)
        {
            int ind = GetIndexOfItemFromInventory(itemData);
            Items[ind].Count = Items[ind].Count + itemData.Count;
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
        data.Name = itemSO.ItemName;
        data.Icon = itemSO.ItemIcon;
        data.Description = itemSO.ItemDescription;
        data.Stackable = itemSO.ItemStackable;
        data.Count = itemSO.ItemCount;
        data.Type= itemSO.ItemType;
        return data;
    }

    public bool HasItemsInInventory(ItemData itemData)
    {
        foreach (ItemData item in Items) 
        {
            if (item.Name == itemData.Name)
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
            if (Items[i].Name == itemData.Name)
            {
                return i;
            }
        }
        return -1;
    }

    public int GetIndexOfItemFromItemUI(GameObject UIItem)
    {
        for (int i = 0; i < ItemsUI.Count; i++)
        {
            if (ItemsUI[i]== UIItem)
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
