using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public ItemData itemData=new ItemData();

    public GameObject iconPanel;
    public GameObject namePanel;
    public GameObject countPanel;
    public GameObject descriptionPanel;

    public bool isEquiped;

    public GameObject oldInventorySlot;
    private GUIItemMouseEvents _gUIItemMouseEvents;
    private GameObject _equipedSlot;
    private GameObject _pocketSlot;
    private GameObject _backpackSlot;



    #region UnityCallBacks
    private void Start()
    {

        _equipedSlot = MainPanel.Instance.EquipedInventorySlot;
        _pocketSlot = MainPanel.Instance.PocketInventorySlot;
        _backpackSlot = MainPanel.Instance.BackpackInventorySlot;
        _gUIItemMouseEvents=GetComponent<GUIItemMouseEvents>();
        if (!itemData.ItemStackable)
        {
            itemData.ItemCount = 1;
            countPanel.SetActive(false);
        }
    }
    #endregion

    #region UICallbacks

    public void OnClickItemButton()
    {
        if (itemData.ItemType == ItemType.Consumable)
            UseItem();
        else if (itemData.ItemType == ItemType.Equipment|| itemData.ItemType == ItemType.Weapon)
            if (isEquiped)
                UnEquipItem();
            else
                EquipItem();
    }
    public void OnClickUseButton()
    {
        UseItem();
        _gUIItemMouseEvents.SwitchGeneralUsagePanel();
    }

    public void OnClickDropButton()
    {
        if (itemData.ItemCount <=1)
        {
            DropItem(itemData.ItemCount);
        }
        else
        {
            InitializeDropPanel();
            _gUIItemMouseEvents.SwitchGeneralUsagePanel();

        }
    }
    public void OnClickCloseButton()
    {
        _gUIItemMouseEvents.SwitchGeneralUsagePanel();
    }
    #endregion

    #region ScriptFunctions

    public bool IsParentEquippedSlot()
    {
        if(transform.parent==_equipedSlot.transform)
            return true;
        return false;
    }

    public void SetItem(ItemData itemData)
    {
        this.itemData= itemData;
    }
    public void UpdateUIElements()
    {
        iconPanel.GetComponent<Image>().sprite=itemData.ItemIcon;
        namePanel.GetComponent<TextMeshProUGUI>().text = itemData.ItemName;
        countPanel.GetComponent<TextMeshProUGUI>().text = itemData.ItemCount +"";
        descriptionPanel.GetComponent<TextMeshProUGUI>().text = itemData.ItemDescription;
    }

    public void UseItem() 
    {
        Debug.Log("ItemUsed");
        InventorySlot inventorySlot= GetComponentInParent<InventorySlot>();
        itemData.ItemCount--;
        if (itemData.ItemCount <=0)
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
        itemData.ItemCount -=count;
        if (itemData.ItemCount <=0)
        {
            // Inventory.RemoveItem(this); 
            inventorySlot.RemoveItem(this, InventorySlot.ItemOperation.Remove);

        }
        
         inventorySlot.UpdateAllItemsUI();
    }

    public void EquipItemWithDrag()
    {
        isEquiped = true;
        InventorySlot oldInventorySlot = GetComponentInParent<InventorySlot>();
        oldInventorySlot.RemoveItem(this, InventorySlot.ItemOperation.Move);
    }

    public void UnEquipItemWithDrag()
    {
        isEquiped = false;
        this.oldInventorySlot = null;
    }

    public void EquipItem()
    {
        //Remove from current Items
        //Remove from current ItemsUI
        isEquiped = true ;
        InventorySlot oldInventorySlot = GetComponentInParent<InventorySlot>();
        oldInventorySlot.RemoveItem(this, InventorySlot.ItemOperation.Move);
        this.oldInventorySlot = transform.parent.gameObject;

        gameObject.transform.SetParent(_equipedSlot.transform);

        //Add to parent Items
        //Add to parent ItemsUI
        InventorySlot newInventorySlot = GetComponentInParent<InventorySlot>();
        newInventorySlot.MoveItem(this);
    }

    public void UnEquipItem()
    {
        InventorySlot oldInventorySlot = GetComponentInParent<InventorySlot>();
        oldInventorySlot.RemoveItem(this, InventorySlot.ItemOperation.Move);

        gameObject.transform.SetParent(this.oldInventorySlot.transform);

        InventorySlot newInventorySlot = GetComponentInParent<InventorySlot>();
        newInventorySlot.MoveItem(this);
        isEquiped= false ;
        this.oldInventorySlot = null;

    }

    public void InitializeDropPanel()
    {
        GameObject dropPanel = MainPanel.Instance.DropPanel;
        dropPanel.SetActive(true);
        DropController dropController= dropPanel.GetComponent<DropController>();
        dropController.Item = this;
        dropController.CountText.text = itemData.ItemCount.ToString();
        dropController.Slider.maxValue = itemData.ItemCount;
        dropController.Slider.value = itemData.ItemCount;
        dropController.NameText.text = itemData.ItemName;
    }

    #endregion
}


