using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DebugMonitor : MonoBehaviour
{
    public TextMeshProUGUI PocketList;
    public TextMeshProUGUI BackpackList;

    public Inventory Inventory;
    public InventorySlot Pocket;
    public InventorySlot Backpack;


    private void Update()
    {
        PocketList.text = "";
        BackpackList.text = "";

        foreach (var item in Pocket.Items)
        {
            PocketList.text += item.Name + "\n";
        }
        foreach (var item in Backpack.Items)
        {
            BackpackList.text += item.Name + "\n";
        }
    }
}
