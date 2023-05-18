using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    

    public ItemData itemData=new ItemData();

    [SerializeField] private GameObject _iconPanel;
    [SerializeField] private GameObject _countPanel;
    [SerializeField] private GameObject _generalPanel;
    [SerializeField] private GameObject _usagePanel;

    public GameObject IconPanel { get => _iconPanel; set => _iconPanel = value; }
    public GameObject CountPanel { get => _countPanel; set => _countPanel = value; }
    public GameObject GeneralPanel { get => _generalPanel; set => _generalPanel = value; }
    public GameObject UsagePanel { get => _usagePanel; set => _usagePanel = value; }





    #region UnityCallBacks
    private void Start()
    {
        if (!itemData.ItemStackable)
        {
            itemData.ItemCount = 1;
            CountPanel.SetActive(false);
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
        SwitchGeneralUsagePanel();
    }

    public void OnClickDropButton()
    {
        if (itemData.ItemCount <= 1)
        {
            
            DropItem(itemData.ItemCount);
        }
        else
        {
            InitializeDropPanel();
            SwitchGeneralUsagePanel();

        }
    }
    public void OnClickCloseButton()
    {
        SwitchGeneralUsagePanel();
    }
    #endregion

    #region ScriptFunctions
    public virtual void UseItem()
    {
        Debug.Log("qw");
        //Look Child Classes
    }
    public void DropItem(int count)
    {
        DecreaseItemCount(count);
        if (itemData.ItemCount<=0)
        {
            Inventory.Instance.RemoveItem(this);
        }
        
    }

    public void IncreaseItemCount(int count)
    {
        itemData.ItemCount += count;
        UpdateUIElements();
    }
    public void DecreaseItemCount(int count)
    {
        itemData.ItemCount -= count;
        UpdateUIElements();
    }

    public void UpdateUIElements()
    {
        IconPanel.GetComponent<Image>().sprite=itemData.ItemIcon;
        CountPanel.GetComponent<TextMeshProUGUI>().text = itemData.ItemCount +"";
    }


    public void SwitchGeneralUsagePanel()
    {
        GeneralPanel.SetActive(!GeneralPanel.activeSelf);
        UsagePanel.SetActive(!UsagePanel.activeSelf);
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

    #region OldScriptFunctions
    //public bool IsParentEquippedSlot()
    //{
    //    if(transform.parent==_equipedSlot.transform)
    //        return true;
    //    return false;
    //}



    //public void UseItem() 
    //{
    //    Debug.Log("ItemUsed");
    //    InventorySlot inventorySlot= GetComponentInParent<InventorySlot>();
    //    itemData.ItemCount--;
    //    if (itemData.ItemCount <=0)
    //    {
    //        inventorySlot.RemoveItem(this,InventorySlot.ItemOperation.Remove);
    //        //Inventory.UpdateUISlot(ItemData);
    //    }
    //    inventorySlot.UpdateAllItemsUI();
    //}

    //public void DropItem(int count) 
    //{

    //    Debug.Log("DropItem");
    //    InventorySlot inventorySlot = GetComponentInParent<InventorySlot>();
    //    itemData.ItemCount -=count;
    //    if (itemData.ItemCount <=0)
    //    {
    //        // Inventory.RemoveItem(this); 
    //        inventorySlot.RemoveItem(this, InventorySlot.ItemOperation.Remove);

    //    }

    //     inventorySlot.UpdateAllItemsUI();
    //}

    //public void EquipItemWithDrag()
    //{
    //    isEquiped = true;
    //    InventorySlot oldInventorySlot = GetComponentInParent<InventorySlot>();
    //    oldInventorySlot.RemoveItem(this, InventorySlot.ItemOperation.Move);
    //}

    //public void UnEquipItemWithDrag()
    //{
    //    isEquiped = false;
    //    this.oldInventorySlot = null;
    //}

    //public void EquipItem()
    //{
    //    //Remove from current Items
    //    //Remove from current ItemsUI
    //    isEquiped = true ;
    //    InventorySlot oldInventorySlot = GetComponentInParent<InventorySlot>();
    //    oldInventorySlot.RemoveItem(this, InventorySlot.ItemOperation.Move);
    //    this.oldInventorySlot = transform.parent.gameObject;

    //    gameObject.transform.SetParent(_equipedSlot.transform);

    //    //Add to parent Items
    //    //Add to parent ItemsUI
    //    InventorySlot newInventorySlot = GetComponentInParent<InventorySlot>();
    //    newInventorySlot.MoveItem(this);
    //}

    //public void UnEquipItem()
    //{
    //    InventorySlot oldInventorySlot = GetComponentInParent<InventorySlot>();
    //    oldInventorySlot.RemoveItem(this, InventorySlot.ItemOperation.Move);

    //    gameObject.transform.SetParent(this.oldInventorySlot.transform);

    //    InventorySlot newInventorySlot = GetComponentInParent<InventorySlot>();
    //    newInventorySlot.MoveItem(this);
    //    isEquiped= false ;
    //    this.oldInventorySlot = null;

    //}
    #endregion

}


