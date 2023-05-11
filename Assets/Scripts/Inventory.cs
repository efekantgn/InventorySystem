using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> InventoryList=new List<Item>();
    public List<GameObject> InventroyUIList=new List<GameObject>();
    public GameObject UIElemnent;
    public GameObject InventoryUI;


    public void AddItem(Item item)
    {
        InventoryList.Add(item);
        SpawnUISlot(item);
    }

    public void RemoveItem()
    {
        InventoryList.RemoveAt(0);
        RemoveUISlot();
    }

    public void SpawnUISlot(Item item)
    {
        GameObject go= Instantiate(UIElemnent);
        go.transform.SetParent(InventoryUI.transform);
        go.GetComponent<ItemDataPlacer>().SetItem(item);
        go.GetComponent<ItemDataPlacer>().SetUIElements();
        InventroyUIList.Add(go);
    }

    public void RemoveUISlot()
    {
        Destroy(InventroyUIList[0]);
        InventroyUIList.RemoveAt(0);
    }

}
