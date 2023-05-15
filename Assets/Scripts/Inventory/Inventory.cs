using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
    public List<ItemData> EquipedList=new List<ItemData>();
    public List<ItemData> PocketList=new List<ItemData>();
    public List<ItemData> BackpackList=new List<ItemData>();
    public List<GameObject> InventroyUIList=new List<GameObject>();
    public GameObject UIElementPrefab;
    public GameObject EquipedInventory;
    public GameObject PocketInventory;
    public GameObject BackpackInventory;
    public GameObject SelectedInventorySlot;

    public static Inventory Instance;

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

    #region ScriptFunctions
    public void AddItem(ItemSO itemSO)
    {
        ItemData tmp= ConvertToItemData(itemSO);

        bool hasInventory = (CheckInventoryHasItem(tmp, PocketList)&& PocketInventory.activeSelf)|| (CheckInventoryHasItem(tmp, BackpackList) && BackpackInventory.activeSelf);


        if (tmp.Stackable && hasInventory)
        {
            int ind = GetItemDataIndex(tmp, GetSelectedInventorySlot());
            GetSelectedInventorySlot()[ind].Count = GetSelectedInventorySlot()[ind].Count + itemSO.Count;
            
            UpdateUISlot(tmp);
        }
        else
        {
            GetSelectedInventorySlot().Add(tmp);
            SpawnUISlot(tmp);
        }
    }
    //Move Item going to add.
    //Remove Item from InventorySlot
    //Add item to InventorySlot
    

    public void RemoveItem(Item item)
    {
        GetSelectedInventorySlot().Remove(item.ItemData);
        InventroyUIList.Remove(item.gameObject);
        Destroy(item.gameObject);
    }

    public void SpawnUISlot(ItemData itemSO)
    {
        GameObject go= Instantiate(UIElementPrefab);
        go.transform.SetParent(SelectedInventoryPanel().transform);
        go.GetComponent<Item>().SetItem(itemSO);
        go.GetComponent<Item>().SetUIElements();
        InventroyUIList.Add(go);
    }

    public void UpdateUISlot(ItemData ItemData)
    {
        foreach (GameObject go in InventroyUIList) 
        {
            go.GetComponent<Item>().Count.GetComponent< TextMeshProUGUI >().text= go.GetComponent<Item>().ItemData.Count+"";
        }
    }

    public ItemData ConvertToItemData(ItemSO itemSO)
    {
        ItemData data=new ItemData();
        data.Name = itemSO.ObjectName;
        data.Icon = itemSO.Icon;
        data.Description = itemSO.Description;
        data.Stackable = itemSO.Stackable;
        data.Count = itemSO.Count;
        return data;
    }

    public bool CheckInventoryHasItem(ItemData itemData, List<ItemData> itemDatas)
    {
        if(GetSelectedInventorySlot()!=itemDatas) return false;
        foreach (var item in itemDatas)
        {
            if (item.Name==itemData.Name)
            {
                return true;
            }
        }
        return false;
    }
    
    public int GetItemDataIndex(ItemData itemData, List<ItemData> itemDatas)
    {
        for (int i = 0; i < itemDatas.Count; i++)
        {
            if (itemDatas[i].Name == itemData.Name)
            {
                return i;
            }
        }
        return -1;
    }

    public List<ItemData> GetSlotOnInventory(ItemData itemData)
    {
        if (CheckInventoryHasItem(itemData,BackpackList))
        {
            return BackpackList;
        }
        else if (CheckInventoryHasItem(itemData, PocketList))
        {
            return PocketList;
        }
        
        else
        {
            return null;
        }
    }

    public List<ItemData> GetSelectedInventorySlot()
    {
        if (BackpackInventory.activeSelf)
        {
            return BackpackList;

        }
        else if (PocketInventory.activeSelf)
        {
            return PocketList;
        }
        else 
        { 
            return null; 
        }
    }

    public GameObject SelectedInventoryPanel()
    {
        if (BackpackInventory.activeSelf)
        {
            return BackpackInventory;

        }
        else if (PocketInventory.activeSelf)
        {
            return PocketInventory;

        }
        else
        {
            return null;
        }
    }

    #endregion

    

}
