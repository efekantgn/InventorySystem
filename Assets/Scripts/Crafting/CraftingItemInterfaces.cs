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
        Debug.Log(itemData.ItemShowable);

        if (itemData == null) return;
        MaterialSelection.SelectedSlot.SlotItemSelected(itemData);
        MaterialSelection.SelectedSlot.SetSelectedData(itemData);

        CraftingManager.Instance.DecreaseItemDataCount(itemData);
        MaterialSelection.SelectedSlot.OnOffMaterialSelectionPanel();
        
    }
}
