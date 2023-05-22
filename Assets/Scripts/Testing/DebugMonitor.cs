using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DebugMonitor : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _inventoryText;
    public TextMeshProUGUI InventoryText { get => _inventoryText; set => _inventoryText = value; }

    private void Update()
    {
        InventoryText.text = "";

        //foreach (var item in Pocket.Items)
        //{
        //    PocketList.text += item.ItemName + "\n";
        //}
        //foreach (var item in Backpack.Items)
        //{
        //    BackpackList.text += item.ItemName + "\n";
        //}
        
        foreach (var item in Inventory.Instance.Items)
        {
            InventoryText.text += item.ItemName + "\n";
        }
    }
}
