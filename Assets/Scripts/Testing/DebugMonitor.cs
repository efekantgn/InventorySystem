using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DebugMonitor : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _inventoryText;
    [SerializeField] private TextMeshProUGUI _inventoryText1;
    [SerializeField] private TextMeshProUGUI _inventoryText2;
    [SerializeField] private TextMeshProUGUI _inventoryText3;
    [SerializeField] private TextMeshProUGUI _inventoryText4;
    [SerializeField] private TextMeshProUGUI _craftingDictionaryText;
    public TextMeshProUGUI InventoryText { get => _inventoryText; set => _inventoryText = value; }
    public TextMeshProUGUI CraftingDictionaryText { get => _craftingDictionaryText; set => _craftingDictionaryText = value; }
    public TextMeshProUGUI InventoryText1 { get => _inventoryText1; set => _inventoryText1 = value; }
    public TextMeshProUGUI InventoryText2 { get => _inventoryText2; set => _inventoryText2 = value; }
    public TextMeshProUGUI InventoryText3 { get => _inventoryText3; set => _inventoryText3 = value; }
    public TextMeshProUGUI InventoryText4 { get => _inventoryText4; set => _inventoryText4 = value; }

    private void Update()
    {
        if(CraftingManager.Instance==null) return;
        InventoryText.text = "";
        InventoryText1.text = "";
        InventoryText2.text = "";
        InventoryText3.text = "";
        InventoryText4.text = "";
        CraftingDictionaryText.text = "";

        
        foreach (var item in CraftingManager.Instance.ItemDatas)
        {
            InventoryText.text += item.ItemName + item.ItemCount+ "\n";
        }
        foreach (var item in CraftingManager.Instance.OneItemRecepies)
        {
            InventoryText1.text += item.Key.ItemID + " : " + item.Value.ItemID + "\n";
        }
        foreach (var item in CraftingManager.Instance.TwoItemRecepies)
        {
            
            InventoryText2.text += item.Key.ItemID + " : ";
            for (int i = 0; i < item.Value.Count; i++)
            {
                InventoryText2.text += item.Value[i].ItemID+", ";
            }
            InventoryText2.text += "\n";
        }
        foreach (var item in CraftingManager.Instance.ThreeItemRecepies)
        {
            InventoryText3.text += item.Key.ItemID + " : ";
            for (int i = 0; i < item.Value.Count; i++)
            {
                InventoryText3.text += item.Value[i].ItemID + ", ";
            }
            InventoryText3.text += "\n";
        }
        foreach (var item in CraftingManager.Instance.FourItemRecepies)
        {
            InventoryText4.text += item.Key.ItemID + " : ";
            for (int i = 0; i < item.Value.Count; i++)
            {
                InventoryText4.text += item.Value[i].ItemID + ", ";
            }
            InventoryText4.text += "\n";
        }
    }
}
