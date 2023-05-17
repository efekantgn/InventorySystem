using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DebugMonitor : MonoBehaviour
{
    public TextMeshProUGUI EquipedList;
    public TextMeshProUGUI PocketList;
    public TextMeshProUGUI BackpackList;

    public InventorySlot Equiped;
    public InventorySlot Pocket;
    public InventorySlot Backpack;


    private void Update()
    {
        EquipedList.text = "";
        PocketList.text = "";
        BackpackList.text = "";

        foreach (var item in Pocket.Items)
        {
            PocketList.text += item.ItemName + "\n";
        }
        foreach (var item in Backpack.Items)
        {
            BackpackList.text += item.ItemName + "\n";
        }
        foreach (var item in Equiped.Items)
        {
            EquipedList.text += item.ItemName + "\n";
        }
    }
}
