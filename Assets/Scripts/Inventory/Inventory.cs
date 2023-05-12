using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
    public List<ItemData> InventoryList=new List<ItemData>();
    public List<GameObject> InventroyUIList=new List<GameObject>();
    public GameObject UIElementPrefab;
    public GameObject InventorySlots;

    #region ScriptFunctions
    public void AddItem(ItemSO itemSO)
    {
        ItemData tmp= ConvertToItemData(itemSO);
        
        if (tmp.Stackable && CheckInventoryHasItem(tmp))
        {
            int ind = GetItemDataIndex(tmp);
            InventoryList[ind].Count = InventoryList[ind].Count+ itemSO.Count;
            UpdateUISlot(tmp);
        }
        else
        {
            InventoryList.Add(tmp);
            SpawnUISlot(tmp);
        }
    }

    public void RemoveItem(Item item)
    {
        InventoryList.Remove(item.ItemData);
        InventroyUIList.Remove(item.gameObject);
        Destroy(item.gameObject);
    }

    public void SpawnUISlot(ItemData itemSO)
    {
        GameObject go= Instantiate(UIElementPrefab);
        go.transform.SetParent(InventorySlots.transform);
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

    public bool CheckInventoryHasItem(ItemData itemData)
    {
        foreach (var item in InventoryList)
        {
            if (item.Name==itemData.Name)
            {
                return true;
            }
        }
        return false;
    }
    
    public int GetItemDataIndex(ItemData itemData)
    {
        for (int i = 0; i < InventoryList.Count; i++)
        {
            if (InventoryList[i].Name == itemData.Name)
            {
                return i;
            }
        }
        return -1;
    }

    #endregion

    

}
