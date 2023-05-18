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

    [SerializeField] private TextMeshProUGUI _inventoryText;
    [SerializeField] private Inventory _inventory;
    public TextMeshProUGUI InventoryText { get => _inventoryText; set => _inventoryText = value; }
    public Inventory Inventory { get => _inventory; set => _inventory = value; }


    private void Update()
    {
        EquipedList.text = "";
        PocketList.text = "";
        BackpackList.text = "";
        InventoryText.text = "";

        //foreach (var item in Pocket.Items)
        //{
        //    PocketList.text += item.ItemName + "\n";
        //}
        //foreach (var item in Backpack.Items)
        //{
        //    BackpackList.text += item.ItemName + "\n";
        //}
        //foreach (var item in Equiped.Items)
        //{
        //    EquipedList.text += item.ItemName + "\n";
        //}
        foreach (var item in Inventory.Items)
        {
            InventoryText.text += item.itemData.ItemName + "\n";
        }
    }
}
