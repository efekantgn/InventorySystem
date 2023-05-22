using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    #region ItemSO variables

    [SerializeField] private int _itemID;
    [SerializeField] private string _itemName;
    [SerializeField] private string _itemDescription;
    [SerializeField] private bool _itemStackable;
    [SerializeField] private int _itemCount = 1;
    [SerializeField] private Sprite _itemIcon;

    public string ItemName { get => _itemName; set => _itemName = value; }
    public string ItemDescription { get => _itemDescription; set => _itemDescription = value; }
    public bool ItemStackable { get => _itemStackable; set => _itemStackable = value; }
    public int ItemCount { get => _itemCount; set => _itemCount = value; }
    public Sprite ItemIcon { get => _itemIcon; set => _itemIcon = value; }
    public int ItemID { get => _itemID; set => _itemID = value; }

    #endregion

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
        if (!ItemStackable)
        {
            ItemCount = 1;
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
        if (ItemCount <= 1)
        {

            DropItem(ItemCount);
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
        //Look Child Classes
    }
    public void DropItem(int count)
    {
        DecreaseItemCount(count);
        if (ItemCount <= 0)
        {
            Inventory.Instance.RemoveItem(this);
        }

    }

    
    public void IncreaseItemCount(int count)
    {
        ItemCount += count;
        UpdateUIElements();
    }
    public void DecreaseItemCount(int count)
    {
        ItemCount -= count;
        UpdateUIElements();
    }

    
    public void UpdateUIElements()
    {
        IconPanel.GetComponent<Image>().sprite = ItemIcon;
        CountPanel.GetComponent<TextMeshProUGUI>().text = ItemCount + "";
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
        DropController dropController = dropPanel.GetComponent<DropController>();
        dropController.Item = this;
        dropController.CountText.text = ItemCount.ToString();
        dropController.Slider.maxValue = ItemCount;
        dropController.Slider.value = ItemCount;
        dropController.NameText.text = ItemName;
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


