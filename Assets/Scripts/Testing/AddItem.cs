using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AddItem : MonoBehaviour
{
    public GameObject[] itemPrefabList;

    public void AddRandomItem()
    {
        int random = UnityEngine.Random.Range(0, itemPrefabList.Length);
        Inventory.Instance.AddItem(itemPrefabList[random],MainPanel.Instance.BackpackPanel.transform);

    }

    public void AddItemWithID(int itemID)
    {
        foreach (var item in itemPrefabList)
        {
            int tmpID = item.GetComponent<Item>().ItemID;
            if (itemID==tmpID)
            {
                Inventory.Instance.AddItem(item, MainPanel.Instance.BackpackPanel.transform);

            }

        }
    }

    public Item FindItemWithID(int ID)
    {
        foreach (var item in itemPrefabList)
        {
            if (item.GetComponent<Item>().ItemID == ID)
            {
                return item.GetComponent<Item>();
            }
        }
        return null;
    }

    public void RemoveItemWithID(int itemID)
    {
        Inventory.Instance.RemoveItem(itemID);
    }

    
    
}
