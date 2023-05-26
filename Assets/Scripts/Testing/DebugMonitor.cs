using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DebugMonitor : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _inventoryText;
    [SerializeField] private TextMeshProUGUI _craftingDictionaryText;
    public TextMeshProUGUI InventoryText { get => _inventoryText; set => _inventoryText = value; }
    public TextMeshProUGUI CraftingDictionaryText { get => _craftingDictionaryText; set => _craftingDictionaryText = value; }

    private void Update()
    {
        InventoryText.text = "";
        CraftingDictionaryText.text = "";

        //foreach (var item in Pocket.Items)
        //{
        //    PocketList.text += item.ItemName + "\n";
        //}
        //foreach (var item in Backpack.Items)
        //{
        //    BackpackList.text += item.ItemName + "\n";
        //}
        
        //foreach (var item in Inventory.Instance.Items)
        //{
        //    InventoryText.text += item.ItemName + "\n";
        //}
        foreach (var item in CraftingManager.Instance.ItemDatas)
        {
            InventoryText.text += item.ItemName + item.ItemCount+ "\n";
        }
        foreach (var item in CraftingManager.Instance.OneItemRecepies)
        {
            CraftingDictionaryText.text += item.Key.ItemID + " : " + item.Value.ItemID + "\n";
        }
    }
}
