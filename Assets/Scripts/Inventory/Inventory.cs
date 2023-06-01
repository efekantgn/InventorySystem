using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Variables
    [SerializeField] private List<Item> _items = new List<Item>();

    [SerializeField] private Body _currentBody;
    [SerializeField] private Head _currentHead;
    [SerializeField] private Foot _currentFoot;
    [SerializeField] private OneHanded _currentOneHanded;
    [SerializeField] private OffHand _currentOffHand;
    [SerializeField] private TwoHanded _currentTwoHand;
    


    public List<Item> Items { get => _items; set => _items = value; }
    public Body CurrentBody { get => _currentBody; set => _currentBody = value; }
    public Head CurrentHead { get => _currentHead; set => _currentHead = value; }
    public Foot CurrentFoot { get => _currentFoot; set => _currentFoot = value; }
    public OneHanded CurrentOneHanded { get => _currentOneHanded; set => _currentOneHanded = value; }
    public OffHand CurrentOffHand { get => _currentOffHand; set => _currentOffHand = value; }
    public TwoHanded CurrentTwoHand { get => _currentTwoHand; set => _currentTwoHand = value; }

    #endregion

    #region Instance

    private static Inventory _instance;
    public static Inventory Instance { get => _instance; set => _instance = value; }

    private void Awake()
    {
        if (Instance == null || Instance != this)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    #endregion


    public void AddItem(GameObject item,Transform parent)
    {
        Item tmp = item.GetComponent<Item>();

        Item FindedItem = FindItemInInventory(tmp);

        if (FindedItem!=null && tmp.ItemStackable)
        {
            FindedItem.IncreaseItemCount(tmp.ItemCount);
        }
        else
        {
            InstantiateUIElement(item, parent);

        }
        
    }

    public void RemoveItem(Item item)
    {
        Destroy(item.gameObject);
        Items.Remove(item);
    }
    public void RemoveItem(int itemID)
    {
        Item item = FindItemInInventory(itemID);
        item.RemoveItem(1);
    }

    public virtual void InstantiateUIElement(GameObject item, Transform parent)
    {
        GameObject tmp=Instantiate(item, parent);
        tmp.GetComponent<Item>().UpdateUIElements();
        Items.Add(tmp.GetComponent<Item>());
    }

    #region ItemsListDataChecks
    
    public Item FindItemInInventory(Item itemData)
    {

        foreach (var item in Items)
        {
            if (item.ItemID == itemData.ItemID)
                return item;
        }
        return null;

    }
    public Item FindItemInInventory(int itemID)
    {

        foreach (var item in Items)
        {
            if (item.ItemID == itemID)
                return item;
        }
        return null;

    }
    #endregion



    #region AddItemWithTheirData
    //public void AddItem(HeadData itemData,Transform parent) 
    //{
    //    if (InventoryHasItem(itemData) && itemData.ItemStackable)
    //    {
    //        FindItemInInventory(itemData).IncreaseItemCount(itemData.ItemCount);
    //    }
    //    else
    //    {
    //        InstantiateUIElement(itemData, parent);

    //    }
    //}

    //public void AddItem(BodyData itemData, Transform parent)
    //{
    //    if (InventoryHasItem(itemData) && itemData.ItemStackable)
    //    {
    //        FindItemInInventory(itemData).IncreaseItemCount(itemData.ItemCount);
    //    }
    //    else
    //    {
    //        InstantiateUIElement(itemData, parent);
    //    }
    //}

    //public void AddItem(FootData itemData, Transform parent)
    //{
    //    if (InventoryHasItem(itemData) && itemData.ItemStackable)
    //    {
    //        FindItemInInventory(itemData).IncreaseItemCount(itemData.ItemCount);
    //    }
    //    else
    //    {
    //        InstantiateUIElement(itemData, parent);
    //    }
    //}

    //public void AddItem(ConsumableData itemData, Transform parent)
    //{
    //    if (InventoryHasItem(itemData) && itemData.ItemStackable)
    //    {
    //        FindItemInInventory(itemData).IncreaseItemCount(itemData.ItemCount);
    //    }
    //    else
    //    {
    //        InstantiateUIElement(itemData, parent);
    //    }
    //}

    //public void AddItem(OneHandedData itemData, Transform parent)
    //{
    //    if (InventoryHasItem(itemData) && itemData.ItemStackable)
    //    {
    //        FindItemInInventory(itemData).IncreaseItemCount(itemData.ItemCount);
    //    }
    //    else
    //    {
    //        InstantiateUIElement(itemData, parent);
    //    }
    //}

    //public void AddItem(TwoHandedData itemData, Transform parent)
    //{
    //    if (InventoryHasItem(itemData) && itemData.ItemStackable)
    //    {
    //        FindItemInInventory(itemData).IncreaseItemCount(itemData.ItemCount);
    //    }
    //    else
    //    {
    //        InstantiateUIElement(itemData, parent);
    //    }
    //}

    //public void AddItem(OffHandData itemData, Transform parent)
    //{
    //    if (InventoryHasItem(itemData) && itemData.ItemStackable)
    //    {
    //        FindItemInInventory(itemData).IncreaseItemCount(itemData.ItemCount);
    //    }
    //    else
    //    {
    //        InstantiateUIElement(itemData, parent);
    //    }
    //}

    #endregion
}
