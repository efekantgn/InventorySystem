using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CraftingItemInterfaces :MonoBehaviour, IPointerClickHandler
{
    MaterialSelection _materialSelection;

    public MaterialSelection MaterialSelection { get => _materialSelection; set => _materialSelection = value; }

    private void Start()
    {
        MaterialSelection = MainPanel.Instance.MaterialSelectionPanel.GetComponent<MaterialSelection>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        ItemData itemData=CraftingManager.Instance.GetItemData(GetComponent<Item>());

        if (itemData == null) return;
        MaterialSelection.SelectedSlot.SetSelectedData(itemData);
        MaterialSelection.SelectedSlot.SlotItemSelected(itemData);
        List<ItemData> itemDatas = new List<ItemData>();
        for (int i = 0; i < OutputSlot.Instance.RecieptSlots.Length; i++)
        {
            if (OutputSlot.Instance.RecieptSlots[i].SelectedData != null)
            {
                itemDatas.Add(OutputSlot.Instance.RecieptSlots[i].SelectedData);

            }
        }
        switch (itemDatas.Count)
        {
            case 1:
                CraftingManager.Instance.CheckCraftableItem(itemDatas[0]);
                break;
            case 2:
                //CheckCraftableItem için 2 parametre kullanan fonksiyonu yazýlacak.
                //CraftingManager.Instance.CheckCraftableItem(itemDatas[0],itemDatas[1]);
                break;
            case 3:
                //CheckCraftableItem için 3 parametre kullanan fonksiyonu yazýlacak.
                //CraftingManager.Instance.CheckCraftableItem(itemDatas[0],itemDatas[1],itemDatas[2]);
                break;
            case 4:
                //CheckCraftableItem için 4 parametre kullanan fonksiyonu yazýlacak.
                //CraftingManager.Instance.CheckCraftableItem(itemDatas[0],itemDatas[1],itemDatas[2],itemDatas[3]);
                break;

            default:
                break;
        }

        CraftingManager.Instance.DecreaseItemDataCount(itemData);
        MaterialSelection.SelectedSlot.OnOffMaterialSelectionPanel();
        
    }
}
