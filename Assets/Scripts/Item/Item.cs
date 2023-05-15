using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public ItemData ItemData;

    public GameObject Icon;
    public GameObject Name;
    public GameObject Count;
    public GameObject Description;

    private GUIItemMouseEvents _GUIItemMouseEvents;

    #region UnityCallBacks
    private void Start()
    {
        
        _GUIItemMouseEvents=GetComponent<GUIItemMouseEvents>();
        if (!ItemData.Stackable)
        {
            ItemData.Count = 1;
            Count.SetActive(false);
        }
    }
    #endregion

    #region UICallbacks

    public void OnClickItemButton()
    {
        UseItem();
    }
    public void OnClickUseButton()
    {
        UseItem();
        _GUIItemMouseEvents.SwitchGeneralUsagePanel();
    }

    public void OnClickDropButton()
    {
        if (ItemData.Count<=1)
        {
            DropItem(ItemData.Count);
        }
        else
        {
            InitializeDropPanel();
            _GUIItemMouseEvents.SwitchGeneralUsagePanel();

        }
    }
    public void OnClickCloseButton()
    {
        _GUIItemMouseEvents.SwitchGeneralUsagePanel();
    }
    #endregion

    #region ScriptFunctions
    public void SetItem(ItemData itemData)
    {
        ItemData= itemData;
    }
    public void SetUIElements()
    {
        Icon.GetComponent<Image>().sprite=ItemData.Icon;
        Name.GetComponent<TextMeshProUGUI>().text = ItemData.Name;
        Count.GetComponent<TextMeshProUGUI>().text = ItemData.Count+"";
        Description.GetComponent<TextMeshProUGUI>().text = ItemData.Description;
    }

    public void UseItem() 
    {
        Debug.Log("ItemUsed");
        InventorySlot inventorySlot= GetComponentInParent<InventorySlot>();
        ItemData.Count--;
        if (ItemData.Count<=0)
        {
            inventorySlot.RemoveItem(this,InventorySlot.ItemOperation.Remove);
            //Inventory.UpdateUISlot(ItemData);
        }
        inventorySlot.UpdateAllItemsUI();
    }

    public void DropItem(int count) 
    {
        Debug.Log("DropItem");
        InventorySlot inventorySlot = GetComponentInParent<InventorySlot>();
        ItemData.Count-=count;
        if (ItemData.Count<=0)
        {
            // Inventory.RemoveItem(this); 
            inventorySlot.RemoveItem(this, InventorySlot.ItemOperation.Remove);

        }
        
         inventorySlot.UpdateAllItemsUI();
    }

    

    public void InitializeDropPanel()
    {
        GameObject dropPanel = MainPanel.Instance.DropPanel;
        dropPanel.SetActive(true);
        DropController dropController= dropPanel.GetComponent<DropController>();
        dropController.Item = this;
        dropController.CountText.text = ItemData.Count.ToString();
        dropController.Slider.maxValue = ItemData.Count;
        dropController.Slider.value = ItemData.Count;
        dropController.NameText.text = ItemData.Name;
    }

    #endregion
}


